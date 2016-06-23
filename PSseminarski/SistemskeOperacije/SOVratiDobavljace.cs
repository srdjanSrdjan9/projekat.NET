using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOVratiDobavljace:OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            try
            {
                Lista = Broker.dajSesiju().vratiSve(new Dobavljac());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
