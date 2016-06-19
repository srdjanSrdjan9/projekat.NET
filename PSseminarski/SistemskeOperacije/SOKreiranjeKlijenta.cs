using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace SistemskeOperacije
{
    public class SOKreiranjeKlijenta
    {
        //public int KreirajKlijenta(Dobavljac k)
        //{
        //    using (var context = new PSContext())
        //    {
        //        using (var transaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                if (!context.Klijenti.Any(klijent => klijent.MaticniBroj == k.MaticniBroj || klijent.Pib == k.Pib))
        //                {
        //                    context.Klijenti.Add(k);
        //                }
        //                else
        //                {
        //                    return -1;
        //                }
        //                context.SaveChanges();
        //                transaction.Commit();
        //            }
        //            catch (Exception e)
        //            {
        //                transaction.Rollback();
        //                return 0;
        //            }

        //        }
        //    }
        //    return 1;
        //}
    }
}
