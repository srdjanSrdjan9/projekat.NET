using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOKreiranjePrijemnice
    {
        public bool KreirajOtpremnicu(Prijemnica p)
        {
            return Broker.dajSesiju().sacuvajPrijemnicu(p);
        }
    }
}
