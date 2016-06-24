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
    public class Prijemnica : Dokument
    {
        [StringLength(50, ErrorMessage = "Način otpreme ne sme imati više od 50 karaktera")]
        public string NacinOtpreme { get; set; }
        public ICollection<StavkaPrijemnice> Stavke { get; set; }
        //public ICollection<Revers> Revers { get; set; }
        [Browsable(false)]
        public long? KorisnikID { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        [Browsable(false)]
        public long? DobavljacID { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }
        
        public Prijemnica()
            : base()
        {

        }
    }
}
