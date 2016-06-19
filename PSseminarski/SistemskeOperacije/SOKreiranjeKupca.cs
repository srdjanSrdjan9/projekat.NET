using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using Sesija;

namespace SistemskeOperacije
{
    public class SOKreiranjeKupca
    {
        public bool sacuvajKupca(Kupac k)
        {
            return Broker.dajSesiju().sacuvajKupca(k);
        }
    }
}
