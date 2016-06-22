using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOVratiDobavljace
    {
        public List<OpstiDomenskiObjekat> vratiSveDobavljace()
        {
            return Broker.dajSesiju().vratiSve(new Dobavljac());
        }
    }
}
