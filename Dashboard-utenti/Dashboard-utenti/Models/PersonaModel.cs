using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.MODELS
{
    public class PersonaModel
    //ID - Nome - Cognome - Data-Nascita - Indirizzo - Città - CAP - Telefono
    {
        public static int IDCount { get; set; } = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cognome { get; set; }
        public DateTimeOffset DataNascita { get; set; }
        public string DataNascitaDisplay => DataNascita.ToString("d");
        public string Indirizzo { get; set; }
        public string Citta { get; set; }

        public int CAP { get; set; }
        public string Telefono { get; set; }
        public PersonaModel()
        {
            ID = IDCount++;
        }
    }
}
