using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesija;
using Model;

namespace SistemskeOperacije
{
    public class SOVratiDokumente : OpstaSIstemskaOperacija
    {
        public override bool izvrsi(OpstiDomenskiObjekat o)
        {
            try
            {
                Lista = Broker.dajSesiju().vratiDokumenta();
                return true;
            }
            catch (Exception exex)
            {
                return false;
            }
        }
    }
}
