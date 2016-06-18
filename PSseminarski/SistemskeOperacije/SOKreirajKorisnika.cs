using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOKreirajKorisnika
    {
        public bool sacuvajKorisnika(Korisnik k)
        {
            return Broker.dajSesiju().sacuvajKorisnika(k);
        }
    }
}
