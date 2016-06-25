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
    public class Revers : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReversID { get; set; }
        public string JedMere { get; set; }
        public int RedniBroj { get; set; }
        public int Ulaz { get; set; }
        public int Izlaz { get; set; }
        public int Ukupno { get; set; }
        [Browsable(false)]
        public int RobaID { get; set; }
        public virtual Roba Roba { get; set; }

        public long DokumentID { get; set; }
        public virtual Prijemnica Prijemnica { get; set; }

        public Revers()
        {

        }

        public string vratiImeTabele()
        {
            throw new NotImplementedException();
        }

        public string vratiKljucIUslov()
        {
            throw new NotImplementedException();
        }

        public string VrednostZaInsert()
        {
            throw new NotImplementedException();
        }

        public List<OpstiDomenskiObjekat> vratiListu()
        {
            throw new NotImplementedException();
        }
    }
}
