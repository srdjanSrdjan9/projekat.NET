using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TransferKlasa
    {
        public Object TransferObjekat { get; set; }
        public long Signal { get; set; }
        public int Operacija { get; set; }
        public bool Uspesnost { get; set; }
    }
}
