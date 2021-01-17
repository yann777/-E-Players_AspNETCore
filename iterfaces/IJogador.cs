using System.Collections.Generic;
using E_Players_AspNetCore.Models;


namespace E_Players_AspNETCore.Interfaces
{
    public interface IJogador
    {
        
        void Create(Jogador j);        
        List<Jogador> ReadAll();        
        void Update(Jogador j);        
        void Delete(int id);  
    }
}