using KontrolerKorisnickogInterfejsa;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class KreiranjePrijemnice : Form
    {
        DokumentiKontroler kki = new DokumentiKontroler();
        KorisniciKontroler korisnici = new KorisniciKontroler();
        KlijentiKontroler klijenti = new KlijentiKontroler();

        public KreiranjePrijemnice()
        {
            InitializeComponent();
            KorisnikRadioButton.Checked = true;
            DobavljacRadioButton.Checked = false;
            korisnici.ucitajKorisnikeUComboBox(KlijentiComboBox);
            kki.ucitajRobuUComboBox(RobaComboBox);
            kki.ucitajRobuUComboBox(comboBox1);
            dataGridView1.DataSource = kki.revers;
            dataGridView2.DataSource = kki.stavkePrijemnice;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DobavljacRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikRadioButton.Checked = false;
            klijenti.ucitajDobavljaceUCombobox(KlijentiComboBox);
        }

        private void KorisnikRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DobavljacRadioButton.Checked = false;
            korisnici.ucitajKorisnikeUComboBox(KlijentiComboBox);
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            int ulaz = 0;
            int izlaz = 0;
            if (UlazRadioButton.Checked)
            {
                ulaz = 1;
            }
            else
            {
                izlaz = 1;
            }

            kki.DodajRevers(jedMereReversTextBox.Text, ulaz, izlaz, RobaComboBox.SelectedItem as Roba, (int)KolicinaNumericUpDown.Value);
        }

        private void DodajStavkubButton_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(comboBox1.SelectedItem as Roba, (int)KolicinaNumericUpDown.Value, JedMereStavkaTextBox.Text, Double.Parse(UkupnaCenaTextBox.Text));
        }

        private void OdustanibButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SacuvajButton_Click(object sender, EventArgs e)
        {
            kki.sacuvajPrijemnicu(MestoTextBox.Text, dateTimePicker1.Value, RobuPrimioTextBox.Text, KlijentiComboBox.SelectedItem as OpstiDomenskiObjekat);
        }
    }
}
