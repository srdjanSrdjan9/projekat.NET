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

        public List<OpstiDomenskiObjekat> pretraziProizvode(Roba roba)
        {
            SOPretrazivanjeProizvoda pr = new SOPretrazivanjeProizvoda();
            pr.IzvrsiSo(roba);
            return pr.Lista;
        }
    }
}
