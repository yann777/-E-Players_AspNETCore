using System.Collections.Generic;
using E_Players_AspNetCore.Models;

namespace E_Players_AspNetCore.iterfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update(Equipe e);

        void Delete(int id);
    }
}