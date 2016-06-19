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

        internal bool? sacuvajDobavljaca(string naziv, string pib, string matBr, string adresa)
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

        public bool ObrisiKorisnika(long id)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranog korisnika? Potvrdom brisanja ne možete povratiti obrisanog korisnika!", "Brisanje korisnika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (k.obrisiKorisnika(id))
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

    }
}
