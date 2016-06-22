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
    public class Dobavljac : OpstiDomenskiObjekat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long DobavljacID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Pib { get; set; }
        public string MaticniBroj { get; set; }

        public Dobavljac()
        {

        }

        public string vratiImeTabele()
        {
            return "Dobavljacs";
        }

        public string vratiKljucIUslov()
        {
            return "DobavljacID=" + DobavljacID;
        }

        public string VrednostZaInsert()
        {
            return "(Naziv, Adresa, Pib, MaticniBroj) VALUES ('" + Naziv + "','" + Adresa + "','" + Pib + "','" + MaticniBroj + "')";
        }

        public override string ToString()
        {
            return Naziv;
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                IEnumerable<Dobavljac> klijenti = context.Dobavljaci;

                if (klijenti == null)
                {
                    return null;
                }

                List<Dobavljac> kupci = klijenti.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                kupci.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}