using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolerKorisnickogInterfejsa
{
    public class KlijentiKontroler : ApstraktniKontrolerKI
    {
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
    }
}
