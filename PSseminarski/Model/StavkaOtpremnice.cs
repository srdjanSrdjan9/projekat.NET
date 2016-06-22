using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Serializable]
    public class StavkaOtpremnice : OpstiDomenskiObjekat
    {
        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Redni broj stavke otpremnice mora biti unet")]
        public int RedniBrojStavke { get; set; }
        public double JedCena { get; set; }
        public double Kolicina { get; set; }
        public double UkupnaCena { get; set; }
        public string JedMere { get; set; }
        [Required]
        public int RobaID { get; set; }
        public virtual Roba Roba { get; set; }
        [Key]
        [Column(Order = 1)]
        public long DokumentID { get; set; }
        //public virtual Otpremnica Otpremnica { get; set; }

        public StavkaOtpremnice()
        { }

        public string vratiImeTabele()
        {
            return "StavkaOtpremnice";
        }

        public string vratiKljucIUslov()
        {
            return "DokumentID=" + DokumentID + ", RedniBrojStavke=" + RedniBrojStavke;
        }

        public string VrednostZaInsert()
        {
            return "(RedniBrojStavke, JedCena, Kolicina, UkupnaCena, JedMere, KlasaID, RobaID, DokumentID) VALUES (" + RedniBrojStavke + "," + JedCena + "," + Kolicina + "," + UkupnaCena + "," + JedMere + "," + RobaID + "," + DokumentID + ")";
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                List<StavkaOtpremnice> stavke = context.StavkeOtpremnice.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                stavke.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}
