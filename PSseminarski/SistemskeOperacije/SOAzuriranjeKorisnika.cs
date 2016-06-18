using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOAzuriranjeKorisnika
    {
        public bool azurirajKorisnika(Korisnik k)
        {
            return Broker.dajSesiju().azurirajKorisnika(k);
        }
    }
}
