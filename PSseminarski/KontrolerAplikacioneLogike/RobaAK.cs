using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SistemskeOperacije;

namespace KontrolerAplikacioneLogike
{
    public class RobaAK
    {
        public List<OpstiDomenskiObjekat> vratiProizvode(string naziv)
        {
            SOVratiRobu so = new SOVratiRobu();
            so.IzvrsiSo(new Roba());
            return so.Lista;
        }
    }
}
