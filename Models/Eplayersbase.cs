using System.IO;
using System.Collections.Generic;

namespace Eplayes_AspCore.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFile(string _path)
        {
            string folder = _path.Split("/")[0];

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);    
            }

            if(!File.Exists(_path))
            {
                File.Create(_path);
            }

        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();


            //using -> responsável para abrir e fechar o arquivo automaticamente.
            //StreamReader -> Ler o arquivo por completo.
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                //Percorre as linhas com um laço de repetição
                while( (linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }

            }

            return linhas;
        }

        public void RewriteCSV(string path, List<string> linhas)
        {
            //StreamWriter -> Escrever dados no arquivo.

            using(StreamWriter output = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + '\n');
                }
            }
        }
    }
}