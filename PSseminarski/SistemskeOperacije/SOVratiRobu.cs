using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOVratiRobu
    {
        public List<OpstiDomenskiObjekat> vratiProizvode()
        {
            return Broker.dajSesiju().vratiSve(new Roba());
        }
    }
}
