using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOKreiranjeDobavljaca
    {
        public bool sacuvajDobavljaca(Dobavljac d)
        {
            return Broker.dajSesiju().sacuvajDobavljaca(d);
        }
    }
}
