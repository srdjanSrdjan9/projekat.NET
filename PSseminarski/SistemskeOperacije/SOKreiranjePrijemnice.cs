using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SistemskeOperacije
{
    public class SOKreiranjePrijemnice
    {
        public int KreirajOtpremnicu(Prijemnica p)
        {
            using (var context = new PSContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Dokumenti.Add(p);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
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
