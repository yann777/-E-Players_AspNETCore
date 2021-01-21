using System.Collections.Generic;
using Eplayes_AspCore.Models;


namespace Eplayes_AspCore.Interfaces
{
    public interface INoticia
    {
        //Criar
        void Create(Noticia n);
        //Ler
        List<Noticia> ReadAll();
        //Alterar
        void Update(Noticia noticiaAlterada);
        //Excluir
        void Delete(int id);  
    }
}