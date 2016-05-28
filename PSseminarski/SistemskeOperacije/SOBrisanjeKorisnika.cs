using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SistemskeOperacije
{
    public class SOBrisanjeKorisnika
    {
        public int ObrisiKorisnika(Korisnik k)
        {
            using (var context = new PSContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Korisnici.Remove(k);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
            return 1;
        }
    }
}
