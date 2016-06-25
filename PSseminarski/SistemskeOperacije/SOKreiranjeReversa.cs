using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOKreiranjeReversa : OpstaSIstemskaOperacija
    {

        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            return Broker.dajSesiju().kreirajRevers(o as Revers);
        }
    }
}
