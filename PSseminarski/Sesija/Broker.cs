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

        #region genericke metode

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
        public bool sacuvajKorisnika(Korisnik k)
        {
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

        public bool ObrisiKorisnika(long id)
        {
            try
            {
                using (var context = new PSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        string query = "DELETE FROM Korisniks WHERE Korisniks.KorisnikID=" + id;
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool azurirajKorisnika(Korisnik k)
        {
            try
            {
                using (var context = new PSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        string query = "UPDATE Korisniks SET Ime='" + k.Ime + "', Prezime='" + k.Prezime + "',Adresa='" + k.Adresa + "',Jmbg='" + k.Jmbg + "' WHERE Korisniks.KorisnikID="+k.KorisnikID;
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

        public bool sacuvajDobavljaca(Dobavljac d)
        {
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
    }
}
