using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Roba
    {
        public int RobaID { get; set; }
        public string Naziv { get; set; }

        public Roba()
        { }
    }
}
