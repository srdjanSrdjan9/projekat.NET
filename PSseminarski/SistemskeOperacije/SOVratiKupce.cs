using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOVratiKupce
    {
        public List<OpstiDomenskiObjekat> vratiKupce()
        {
            return Broker.dajSesiju().vratiSve(new Kupac());
        }
    }
}
