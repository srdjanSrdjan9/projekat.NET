using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Sesija;

namespace SistemskeOperacije
{
    public class SOPretrazivanjeProizvoda : OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            try
            {
                Lista = Broker.dajSesiju().pretraziProizvode(o);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
