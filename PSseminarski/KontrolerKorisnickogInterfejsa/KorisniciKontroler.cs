using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolerKorisnickogInterfejsa
{
    public class KorisniciKontroler:ApstraktniKontrolerKI
    {
        public BindingList<Korisnik> korisnici = new BindingList<Korisnik>();

        public void ucitajKorisnikeUComboBox(ComboBox c)
        {
            List<Korisnik> korisniciPomocna = new List<Korisnik>();
            k.vratiSveKorisnike().ForEach(x => korisniciPomocna.Add(x as Korisnik));

            c.DataSource = korisniciPomocna;
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
    }
}
