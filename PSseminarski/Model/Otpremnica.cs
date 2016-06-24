using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Serializable]
    public class Otpremnica : Dokument
    {
        //[Required(ErrorMessage = "Redni broj otpremnice mora biti unet")]
        //public int BrojOtpremnice { get; set; }
        public ICollection<StavkaOtpremnice> Stavke { get; set; }

        [Browsable(false)]
        public long KupacID { get; set; }
        public virtual Kupac Kupac { get; set; }

        public Otpremnica()
            : base()
        {

        }
    }
}
