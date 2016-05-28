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
        [Required(ErrorMessage = "Redni broj prijemnice mora biti unet")]
        public int BrojPrijemnice { get; set; }
        public ICollection<StavkaPrijemnice> Stavke { get; set; }
        [Required]
        public long KlijentID { get; set; }
        public virtual Klijent Klijent { get; set; }
        
        public Prijemnica()
            : base()
        {

        }
    }
}
