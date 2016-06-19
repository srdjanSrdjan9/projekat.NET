using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Kupac
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long KupacID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Pib { get; set; }
        public string MaticniBroj { get; set; }

        public Kupac()
        {

        }

        public string vratiImeTabele()
        {
            return "Kupacs";
        }

        public string vratiKljucIUslov()
        {
            return "KupacID=" + KupacID;
        }

        public string VrednostZaInsert()
        {
            return "(Naziv, Adresa, Pib, MaticniBroj) VALUES (" + Naziv + "," + Adresa + "," + Pib + "," + MaticniBroj + ")";
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                IEnumerable<Kupac> klijenti = context.Kupci;

                if (klijenti == null)
                {
                    return null;
                }

                List<Kupac> kupci = klijenti.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                kupci.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}
