using System.Collections.Generic;
using Eplayes_AspCore.Models;

namespace Eplayes_AspCore.Interfaces
{
    public interface IJogador
    {
         //Criar
        void Create(Jogador j);
        //Ler
        List<Jogador> ReadAll();
        //Alterar
        void Update(Jogador j);
        //Excluir
        void Delete(int id);  
    }
}