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
    public class DokumentiKontroler : ApstraktniKontrolerKI
    {
        public Prijemnica prijemnica = new Prijemnica();
        public BindingList<Revers> revers = new BindingList<Revers>();
        public BindingList<StavkaPrijemnice> stavkePrijemnice = new BindingList<StavkaPrijemnice>();
        public Otpremnica otpremnica = new Otpremnica();
        public BindingList<StavkaOtpremnice> stavkeOtpr = new BindingList<StavkaOtpremnice>();
        public BindingList<Dokument> dokumenta = new BindingList<Dokument>();

        public void ucitajDokumentaUDataGrid(DataGridView d)
        {
            dokumenta.Clear();
            k.vratiDokumenta().ForEach(x => dokumenta.Add(x as Dokument));
            d.DataSource = dokumenta;
        }

        #region prijemnice
        public void ucitajRobuUComboBox(ComboBox c)
        {
            List<Roba> roba = new List<Roba>();
            k.vratiRobu().ForEach(x => roba.Add(x as Roba));

            c.DataSource = roba;
        }

        public void PopuniStanje(Roba r, TextBox primljenotxt, TextBox prodatotxt)
        {
            double primljeno = 0;
            double prodato = 0;
            List<OpstiDomenskiObjekat> asd = k.pretraziProizvode(r);
            asd.ForEach(c =>
            {
                try
                {
                    StavkaOtpremnice s = c as StavkaOtpremnice;
                    prodato += s.Kolicina;
                }
                catch (Exception)
                {
                    StavkaPrijemnice p = c as StavkaPrijemnice;
                    primljeno += p.Kolicina;
                }
            });
            primljenotxt.Text = primljeno.ToString();
            prodatotxt.Text = prodato.ToString();
        }

        public void dodajStavkuOtpremnice(string text1, int value, string text2, Roba roba)
        {
            if (text1 == "" || text2 == "")
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }
            stavkeOtpr.Add(new StavkaOtpremnice()
            {
                JedMere = text1,
                Kolicina = value,
                JedCena = Int32.Parse(text2),
                Roba = roba,
                RedniBrojStavke = stavkeOtpr.Count + 1,
                UkupnaCena = value * Int32.Parse(text2)
            });

        }

        public bool sacuvajOtpremnicu(string text, DateTime value, Kupac kupac)
        {
            if (stavkeOtpr.Count == 0)
            {
                MessageBox.Show("Otpremnica mora imati bar jednu stavku");
                return false;
            }
            otpremnica.Mesto = text;
            otpremnica.Kupac = kupac;
            otpremnica.DatumIzdavanja = value;
            otpremnica.Stavke = stavkeOtpr.ToList();

            if (k.sacuvajOtpremnicu(otpremnica))
            {
                MessageBox.Show("Otpremnica je uspešno sačuvana!");
                return true;
            }
            else
            {
                MessageBox.Show("Otpremnica nije uspešno sačuvana!");
                return false;
            }
        }

        public void DodajRevers(string jedinicaMere, int Ulaz, int Izlaz, Roba roba, string kolicina)
        {
            int asd;
            if (!Int32.TryParse(kolicina, out asd))
            {
                MessageBox.Show("Kolicina mora biti broj!");
                return;
            }
            Revers r = new Revers()
            {
                JedMere = jedinicaMere,
                Ulaz = Ulaz,
                Izlaz = Izlaz,
                Roba = roba,
                Ukupno = asd,
                RedniBroj = revers.Count + 1
            };
            revers.Add(r);
        }

        public void dodajStavku(Roba roba, int value, string text, string v)
        {
            double asd;
            if (!Double.TryParse(v, out asd))
            {
                MessageBox.Show("Cena mora biti broj!");
                return;
            }
            stavkePrijemnice.Add(new StavkaPrijemnice()
            {
                RedniBrojStavke = stavkePrijemnice.Count + 1,
                Roba = roba,
                Kolicina = value,
                JedMere = text,
                JedCena = asd,
                UkupnaCena = value * asd
            });
        }

        public bool sacuvajPrijemnicu(string text1, DateTime dateTime, string text2, OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            if (stavkePrijemnice.Count == 0)
            {
                MessageBox.Show("Prijemnica mora imati bar jednu stavku!");
                return false;
            }
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
            // TODO: REVERS
            // prijemnica.Revers = revers.ToList();
            prijemnica.Stavke = stavkePrijemnice.ToList();
            prijemnica.Revers = revers.ToList();
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
            //if (k.kreirajRevers(revers.ToList()))
            //{
            //    MessageBox.Show("Revers je uspesno dodat!");
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show("Revers nije uspesno dodat!");
            //    return false;
            //}

        }
        #endregion

        #region otpremnice

        #endregion

    }
}
