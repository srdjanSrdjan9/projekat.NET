using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Serializable]
    public abstract class Dokument : OpstiDomenskiObjekat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long DokumentID { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Mesto { get; set; }
        public string RobuPrimio { get; set; }

        public Dokument()
        {
            DatumIzdavanja = DateTime.Now;
        }

        public string vratiImeTabele()
        {
            return "Dokument";
        }

        public string vratiKljucIUslov()
        {
            return "DokumentID=" + DokumentID;
        }

        public string VrednostZaInsert()
        {
            return "(DatumIzdavanja, Mesto, RobuPrimio) VALUES + ('" + DatumIzdavanja + "','" + Mesto + "','" + RobuPrimio + "')";
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            using (var context = new PSContext())
            {
                List<Dokument> dokumenti = context.Dokumenti.ToList();
                List<OpstiDomenskiObjekat> objekti = new List<OpstiDomenskiObjekat>();
                dokumenti.ForEach(d => objekti.Add(d as OpstiDomenskiObjekat));
                return objekti;
            }
        }
    }
}
