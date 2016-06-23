using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SistemskeOperacije
{
    public abstract class OpstaSIstemskaOperacija
    {
        List<OpstiDomenskiObjekat> lista;

        public List<OpstiDomenskiObjekat> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

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
