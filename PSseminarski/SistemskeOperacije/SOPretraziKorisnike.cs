using Model;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOPretraziKorisnike:OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            try
            {
                Lista = Broker.dajSesiju().vratiSve(new Korisnik());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
