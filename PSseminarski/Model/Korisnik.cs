using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Serializable]
    public class Korisnik : OpstiDomenskiObjekat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        [StringLength(13, ErrorMessage = "JMBG korisnika mora imati tacno 13 karaktera!")]
        public string Jmbg { get; set; }
        public DateTime DatumRegistrovanja { get; set; }

        public Korisnik()
        {
            DatumRegistrovanja = DateTime.Now;
        }

        public string vratiImeTabele()
        {
            return "Korisniks";
        }

        public string vratiKljucIUslov()
        {
            return "KorisnikID=" + KorisnikID;
        }

        public string VrednostZaInsert()
        {
            return "(Ime, Prezime, Adresa, Jmbg, DatumRegistrovanja) VALUES ('" + Ime + "','" + Prezime + "','" + Adresa + "','" + Jmbg + "','" + DatumRegistrovanja + "')";
        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                IEnumerable<Korisnik> asd = context.Korisnici;
                if (asd == null)
                {
                    return null;
                }
                List<Korisnik> korisnici = asd.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                korisnici.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}
