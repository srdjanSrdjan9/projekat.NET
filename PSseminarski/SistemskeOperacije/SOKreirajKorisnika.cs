﻿using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOKreirajKorisnika:OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            return Broker.dajSesiju().sacuvajKorisnika(o);
        }
    }
}
