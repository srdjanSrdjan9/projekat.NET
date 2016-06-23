using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public class KontrolerKI
    {
        static Komunikacija k = new Komunikacija();
        public BindingList<Korisnik> korisnici = new BindingList<Korisnik>();
        public Prijemnica prijemnica = new Prijemnica();
        public BindingList<Revers> revers = new BindingList<Revers>();
        public BindingList<StavkaPrijemnice> stavkePrijemnice = new BindingList<StavkaPrijemnice>();

        public bool poveziSeSaServerom()
        {
            bool rezultat = k.poveziSeSaServerom();
            if (rezultat)
            {
                MessageBox.Show("Uspesna konekcija!");
                return true;
            }
            else
            {
                MessageBox.Show("Neuspesna konekcija!");
                return false;
            }
        }

        public bool? sacuvajDobavljaca(string naziv, string pib, string matBr, string adresa)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate dobavljača?", "Kreiranje dobavljača", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return null;
            }

            Dobavljac d = new Dobavljac()
            {
                Naziv = naziv,
                Pib = pib,
                MaticniBroj = matBr,
                Adresa = adresa
            };

            if (k.sacuvajDobavljaca(d))
            {
                MessageBox.Show("Dobavljač je uspešno sačuvan!");
                return true;
            }
            else
            {
                MessageBox.Show("Dobavljač nije uspešno sačuvan!");
                return false;
            }
        }

        public bool? sacuvajKupca(string naziv, string pib, string matBr, string adresa)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate kupca?", "Kreiranje kupca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return null;
            }

            Kupac kupac = new Kupac()
            {
                Naziv = naziv,
                Pib = pib,
                MaticniBroj = matBr,
                Adresa = adresa
            };

            if (k.sacuvajKupca(kupac))
            {
                MessageBox.Show("Kupac je uspešno sačuvan!");
                return true;
            }
            else
            {
                MessageBox.Show("Kupac nije uspešno sačuvan!");
                return false;
            }
        }

        public void dajKorisnike(DataGridView d)
        {
            List<OpstiDomenskiObjekat> pomocna = k.vratiSveKorisnike();
            if (pomocna == null)
            {
                MessageBox.Show("U baze trenutno ne postoji nijedan korisnik!");
                return;
            }
            korisnici.Clear();
            pomocna.ForEach(x => korisnici.Add(x as Korisnik));

            d.DataSource = korisnici;
        }

        public bool? sacuvajKorisnika(string ime, string prezime, string adresa, string jmbg)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da dodate korisnika?", "Kreiranje korisnika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return null;
            }
            Korisnik korisnik = new Korisnik()
            {
                Ime = ime,
                Prezime = prezime,
                Adresa = adresa,
                Jmbg = jmbg,
                DatumRegistrovanja = DateTime.Now
            };

            if (k.sacuvajKorisnika(korisnik))
            {
                MessageBox.Show("Korisnik je uspešno sačuvan!");
                return true;
            }
            else
            {
                MessageBox.Show("Korisnik nije uspešno sačuvan. Pokušajte ponovo kasnije!");
                return false;
            }
        }

        public bool ObrisiKorisnika(Korisnik ka)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranog korisnika? Potvrdom brisanja ne možete povratiti obrisanog korisnika!", "Brisanje korisnika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (k.obrisiKorisnika(ka))
                {
                    MessageBox.Show("Korisnik je uspešno obrisan!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Korisnik nije uspešno obrisan!");
                    return false;
                }
            }
            return false;
        }

        public bool azurirajKorisnika(long id, string ime, string prezime, string adresa, string jmbg)
        {
            Korisnik korisnik = new Korisnik()
            {
                KorisnikID = id,
                Ime = ime,
                Prezime = prezime,
                Adresa = adresa,
                Jmbg = jmbg
            };

            var result = MessageBox.Show("Da li ste sigurni da želite da ažurirate izabranog korisnika? Potvrdom ažuriranja podaci o korisniku će biti trajno promenjeni!", "Ažuriranje korisnika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (k.azurirajKorisnika(korisnik))
                {
                    MessageBox.Show("Korisnik je uspešno ažuriran!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Korisnik nije uspešno ažuriran!");
                    return false;
                }
            }
            return false;
        }

        public void ucitajKorisnikeUComboBox(ComboBox c)
        {
            List<Korisnik> korisniciPomocna = new List<Korisnik>();
            k.vratiSveKorisnike().ForEach(x => korisniciPomocna.Add(x as Korisnik));

            c.DataSource = korisniciPomocna;
        }

        public void ucitajDobavljaceUCombobox(ComboBox c)
        {
            List<Dobavljac> dobavljaci = new List<Dobavljac>();
            k.vratiDobavljace().ForEach(x => dobavljaci.Add(x as Dobavljac));

            c.DataSource = dobavljaci;
        }

        public void ucitajKupceUComboBox(ComboBox c)
        {
            List<Kupac> kupci = new List<Kupac>();
            k.vratiKupce().ForEach(x => kupci.Add(x as Kupac));

            c.DataSource = kupci;
        }

        public void ucitajRobuUComboBox(ComboBox c)
        {
            List<Roba> roba = new List<Roba>();
            k.vratiRobu().ForEach(x => roba.Add(x as Roba));

            c.DataSource = roba;
        }

        public void DodajRevers(string jedinicaMere, int Ulaz, int Izlaz, Roba roba, int kolicina)
        {
            this.revers.Add(new Revers()
            {
                JedMere = jedinicaMere,
                Ulaz = Ulaz,
                Izlaz = Izlaz,
                Roba = roba,
                Ukupno = kolicina,
                RedniBroj = revers.Count + 1
            });
        }

        public void dodajStavku(Roba roba, int value, string text, double v)
        {
            stavkePrijemnice.Add(new StavkaPrijemnice()
            {
                RedniBrojStavke = stavkePrijemnice.Count + 1,
                Roba = roba,
                Kolicina = value,
                JedMere = text,
                JedCena = v,
                UkupnaCena = value * v
            });
        }

        internal bool sacuvajPrijemnicu(string text1, DateTime dateTime, string text2, OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            prijemnica.Mesto = text1;
            prijemnica.DatumIzdavanja = dateTime;
            prijemnica.RobuPrimio = text2;
            if (opstiDomenskiObjekat.vratiImeTabele() == "Korisniks")
            {
                prijemnica.Korisnik = opstiDomenskiObjekat as Korisnik;
            }
            else
            {
                prijemnica.Dobavljac = opstiDomenskiObjekat as Dobavljac;
            }

            prijemnica.Revers = revers.ToList();
            prijemnica.Stavke = stavkePrijemnice.ToList();
            
            if (k.sacuvajPrijemnicu(prijemnica))
            {
                MessageBox.Show("Prijemnica je uspešno sačuvana!");
                return true;
            }
            else
            {
                MessageBox.Show("Prijemnica nije uspešno sačuvana!");
                return false;
            }
        }

    }
}
