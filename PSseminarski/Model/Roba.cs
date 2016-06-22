using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Roba:OpstiDomenskiObjekat
    {
        public int RobaID { get; set; }
        public string Naziv { get; set; }

        public Roba()
        { }

        public string vratiImeTabele()
        {
            return "Robas";
        }

        public string vratiKljucIUslov()
        {
            return "RobaID=" + RobaID;
        }

        public string VrednostZaInsert()
        {
            return "(Naziv) VALUES (" + Naziv + ")";
        }

        public override string ToString()
        {
            return Naziv;
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                List<Roba> roba = context.Roba.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                roba.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}
