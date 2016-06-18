using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOPretraziKorisnike
    {
        public List<OpstiDomenskiObjekat> vratiKorisnike()
        {
            return Broker.dajSesiju().vratiSve(new Korisnik());
        }
    }
}
