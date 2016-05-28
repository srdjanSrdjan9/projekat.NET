using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Serializable]
    public class Otpremnica : Dokument
    {
        [Required(ErrorMessage = "Redni broj otpremnice mora biti unet")]
        public int BrojOtpremnice { get; set; }
        public ICollection<StavkaOtpremnice> Stavke { get; set; }
        [Required]
        public long KlijentID { get; set; }
        public virtual Klijent Klijent { get; set; }

        public Otpremnica()
            : base()
        {

        }
    }
}
