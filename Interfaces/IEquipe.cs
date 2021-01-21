using Eplayes_AspCore.Models;
using System.Collections.Generic;

namespace Eplayes_AspCore.Interfaces
{
    public interface IEquipe
    {

        //Métodos de CRUD - Contrato de negócio
        void Create(Equipe e); 

        List<Equipe> ReadAll();

        void Update(Equipe equipeAlterada);

        void Delete(int id);
    }
}