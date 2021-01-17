using System.Collections.Generic;
using System.IO;
using E_Players_AspNetCore.iterfaces;

namespace E_Players_AspNetCore.Models
{
    public class Jogador : Eplayersbase , IJogador
    {
        public Jogador(int idJogador, string nome, int idEquipe, string email, string senha)
        {
            this.IdJogador = idJogador;
            this.Nome = nome;
            this.IdEquipe = idEquipe;
            this.Email = email;
            this.Senha = senha;

        }
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }

        // Login
        public string Email { get; set; }
        public string Senha { get; set; }

         private const string PATH = "Database/Jogador.csv";

    public Jogador()
    {
        CreateFolderAndFile(PATH);
    }
     /// <summary>
        /// Adiciona uma Jogador ao CSV
        /// </summary>
        /// <param name="j">Jogador</param>
        public void Create(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Prepara a linha para a estrutura do objeto Jogador
        /// </summary>
        /// <param name="e">Objeto "Jogador"</param>
        /// <returns>Retorna a linha em formato de .csv</returns>
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha}";
        }

        /// <summary>
        /// Exclui uma Jogador
        /// </summary>
        /// <param name="idJogador"></param>
        public void Delete(int idJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());                        
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê todos as linhas do csv
        /// </summary>
        /// <returns>Lista de Jogadors</returns>
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

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        /// <summary>
        /// Altera uma Jogador
        /// </summary>
        /// <param name="j">Jogador alterada</param>
        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(j) );                        
            RewriteCSV(PATH, linhas); 
        }
    }
}