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
        public Object transferObjekat { get; set; }
        public int signal { get; set; }
        public int operacija { get; set; }
    }
}
