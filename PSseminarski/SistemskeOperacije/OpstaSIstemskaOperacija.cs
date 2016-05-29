using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SistemskeOperacije
{
    abstract class OpstaSIstemskaOperacija
    {
        public bool IzvrsiSo(OpstiDomenskiObjekat odo)
        {
            bool rezultat;
            using (var context = new PSContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    rezultat = izvrsi(odo);
                    if (rezultat)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            return rezultat;
        }
        public abstract bool izvrsi(OpstiDomenskiObjekat o);
    }
}
