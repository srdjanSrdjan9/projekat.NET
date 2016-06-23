﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOKreiranjePrijemnice:OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            return Broker.dajSesiju().sacuvajPrijemnicu(o);
        }
    }
}
