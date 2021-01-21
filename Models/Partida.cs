using System;

namespace Eplayes_AspCore.Models
{
    public class Partida
    {

        public int IdPartida { get; set; }

        public int IdJogador1 { get; set; }

        public int IdJogador2 { get; set; }
        
        public DateTime DataInicio {get;set;}

        public DateTime HoraInicio {get;set;}
        
    }
}