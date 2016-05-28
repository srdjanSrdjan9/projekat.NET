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
    public class StavkaPrijemnice
    {
        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Redni broj stavke prijemnice mora biti unet")]
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
        [ForeignKey("Prijemnica")]
        public long DokumentID { get; set; }
        public virtual Prijemnica Prijemnica { get; set; }

        public StavkaPrijemnice()
        { }
    }
}
