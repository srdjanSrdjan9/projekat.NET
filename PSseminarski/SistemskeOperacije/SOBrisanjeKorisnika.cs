using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOBrisanjeKorisnika
    {
        public bool obrisiKorisnika(long id)
        {
            return Broker.dajSesiju().ObrisiKorisnika(id);
        }
    }
}
