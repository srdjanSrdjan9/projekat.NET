using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Serializable]
    public class Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public long KlijentID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Pib { get; set; }
        public string MaticniBroj { get; set; }

        public Klijent()
        {

        }
    }
}