using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Serializable]
    public class Klijent:OpstiDomenskiObjekat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long KlijentID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Pib { get; set; }
        public string MaticniBroj { get; set; }

        public Klijent()
        {

        }

        public string vratiImeTabele()
        {
            return "Klijent";
        }

        public string vratiKljucIUslov()
        {
            return "KlijentID=" + KlijentID;
        }

        public string VrednostZaInsert()
        {
            return "(Naziv, Adresa, Pib, MaticniBroj) VALUES (" + Naziv + "," + Adresa + "," + Pib + "," + MaticniBroj + ")";
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                List<Klijent> klijenti = context.Klijenti.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                klijenti.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}