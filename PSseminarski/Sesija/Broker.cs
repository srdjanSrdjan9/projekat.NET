using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Sesija
{
    public class Broker
    {
        static Broker instanca;

        private Broker()
        {

        }

        public static Broker dajSesiju()
        {
            if (instanca == null)
            {
                instanca = new Broker();
            }

            return instanca;
        }



        //public bool sacuvajPrijemnicu(Prijemnica prijemnica)
        //{
        //    //int reversCount = 0;
        //    //int stavkeCount = 0;
        //    try
        //    {
        //        using (var context = new PSContext())
        //        {
        //            using (var transaction = context.Database.BeginTransaction())
        //            {
        //                //string uputPr = "insert into Dokuments (DatumIzdavanja, Mesto, RobuPrimio, Discriminator)" ;
        //                //int rez1 = context.Database.ExecuteSqlCommand(uputPr);

        //                context.Dokumenti.Add(prijemnica);
        //                context.SaveChanges();
        //                long id = prijemnica.DokumentID;

        //                string upit = "";

        //                //foreach (StavkaPrijemnice item in prijemnica.Stavke)
        //                //{
        //                //    // item.DokumentID = id;
        //                //    upit = "insert into StavkaPrijemnices " + item.VrednostZaInsert();

        //                //    int rez = context.Database.ExecuteSqlCommand(upit);
        //                //    if (rez == 1)
        //                //    {
        //                //        stavkeCount++;
        //                //    }
        //                //    //context.StavkePrijemnice.Add(item);

        //                //}

        //                //foreach (Revers item in prijemnica.Revers)
        //                //{
        //                //    //item.Prijemnica = prijemnica;
        //                //    item.Prijemnica = prijemnica;
        //                //    context.Revers.Add(item);
        //                //    reversCount++;
        //                //}

        //                context.SaveChanges();

        //                transaction.Commit();
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        #region genericke metode

        public List<OpstiDomenskiObjekat> vratiDokumenta()
        {
            List<OpstiDomenskiObjekat> dokumenti = new List<OpstiDomenskiObjekat>();
            using (var context = new PSContext())
            {
                List<Dokument> asd = context.Dokumenti.ToList();
                asd.ForEach(x => dokumenti.Add(x as OpstiDomenskiObjekat));
            }
            return dokumenti;
        }

        public List<OpstiDomenskiObjekat> vratiSve(OpstiDomenskiObjekat odo)
        {
            try
            {
                return odo.vratiListu();
            }
            catch (Exception)
            {
                throw new Exception("Došlo je do greške prilikom učitavanja korisnika!");
            }
        }

        #endregion

        #region korisnici
        public bool sacuvajKorisnika(OpstiDomenskiObjekat o)
        {
            Korisnik k = o as Korisnik;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transakcija = context.Database.BeginTransaction())
                    {
                        if (context.ubaci(k))
                        {
                            transakcija.Commit();
                            return true;
                        }
                        else
                        {
                            transakcija.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ObrisiKorisnika(OpstiDomenskiObjekat o)
        {
            Korisnik k = o as Korisnik;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        string query = "DELETE FROM Korisniks WHERE Korisniks.KorisnikID=" + k.KorisnikID;
                        int result = context.Database.ExecuteSqlCommand(query);
                        if (result == 1)
                        {
                            transaction.Commit();
                            return true;
                        }
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool azurirajKorisnika(OpstiDomenskiObjekat o)
        {
            Korisnik k = o as Korisnik;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        string query = "UPDATE Korisniks SET Ime='" + k.Ime + "', Prezime='" + k.Prezime + "',Adresa='" + k.Adresa + "',Jmbg='" + k.Jmbg + "' WHERE Korisniks.KorisnikID=" + k.KorisnikID;
                        int result = context.Database.ExecuteSqlCommand(query);
                        if (result == 1)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region dobavljaci

        public bool sacuvajDobavljaca(OpstiDomenskiObjekat o)
        {
            Dobavljac d = o as Dobavljac;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transakcija = context.Database.BeginTransaction())
                    {
                        if (context.ubaci(d))
                        {
                            transakcija.Commit();
                            return true;
                        }
                        else
                        {
                            transakcija.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region kupci

        public bool sacuvajKupca(OpstiDomenskiObjekat o)
        {
            Kupac k = o as Kupac;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transakcija = context.Database.BeginTransaction())
                    {
                        if (context.ubaci(k))
                        {
                            transakcija.Commit();
                            return true;
                        }
                        else
                        {
                            transakcija.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region dokumenti

        public bool sacuvajOtpremnicu(OpstiDomenskiObjekat o)
        {
            Otpremnica otpremnica = o as Otpremnica;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transakcija = context.Database.BeginTransaction())
                    {
                        context.Dokumenti.Add(otpremnica);
                        if (context.SaveChanges() > 0)
                        {
                            transakcija.Commit();
                            return true;
                        }
                        else
                        {
                            transakcija.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool sacuvajPrijemnicu(OpstiDomenskiObjekat o)
        {
            Prijemnica prijemnica = o as Prijemnica;
            try
            {
                using (var context = new PSContext())
                {
                    using (var transakcija = context.Database.BeginTransaction())
                    {
                        context.Dokumenti.Add(prijemnica);
                        if (context.SaveChanges() > 0)
                        {
                            transakcija.Commit();
                            return true;
                        }
                        else
                        {
                            transakcija.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
