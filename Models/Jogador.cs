using Eplayes_AspCore.Interfaces;
using System.IO;
using System.Collections.Generic;
using Eplayes_AspCore.Controllers;

namespace Eplayes_AspCore.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set;}

        public int IdEquipe { get; set; }

        private string PATH = "Database/Jogador.csv";

         public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

    
        public void Create(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }


        public void Delete(int idJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());                        
            RewriteCSV(PATH, linhas);
        }

        
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.Email = linha[2];
                jogador.Senha = linha[3];
                jogador.IdEquipe = int.Parse(linha[4]);

                jogadores.Add(jogador);
            }
            return jogadores;
        }

       
        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(j) );                        
            RewriteCSV(PATH, linhas); 
        }

        

    }
}