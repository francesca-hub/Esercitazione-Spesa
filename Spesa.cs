using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
    public class Spesa
    {

        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }
        public bool Approvata { get; set; }
        public string Livello { get; set; }
        public decimal ImportoRimborsato { get; set; }

        public string DettaglioSpesa()
        {
            return $"{Data.ToShortDateString()}; {Categoria}; {Descrizione}; {Importo}";
        }

        public string DettaglioApprovazione()
        {
            if (Approvata)
                return $"{Data.ToShortDateString()};{Categoria};{Descrizione};APPROVATA:{Livello};{ImportoRimborsato}";
            else
                return $"{Data.ToShortDateString()};{Categoria};{Descrizione};RESPINTA";
        }

    }

    public enum Categoria
    {
        Viaggio,
        Alloggio,
        Vitto,
        Altro
    }

}