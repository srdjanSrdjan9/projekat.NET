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
    public class Korisnik
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
    }
}
