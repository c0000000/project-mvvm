using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.MODELS
{
    public class Persona
    //ID - Nome - Cognome - Data-Nascita - Indirizzo - Città - CAP - Telefono
    {
        private static int IDCount = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }

        public int CAP { get; set; }
        public string Telefono { get; set; }
        public Persona()
        {
            ID = IDCount++;
        }
        public Persona(int ID,string name)
        {
            this.ID = IDCount++; ;
            this.Name = name;
        }
    }
}
