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
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton1.CheckedChanged += radioButtons_CheckedChanged;
            radioButton2.CheckedChanged += radioButtons_CheckedChanged;
            UlazRadioButton.Checked = true;
            IzlazRadioButton.Checked = false;
            korisnici.ucitajKorisnikeUComboBox(KlijentiComboBox);
            kki.ucitajRobuUComboBox(RobaComboBox);
            kki.ucitajRobuUComboBox(comboBox1);
            dataGridView1.DataSource = kki.revers;
            dataGridView2.DataSource = kki.stavkePrijemnice;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton1.Checked)
            {
                korisnici.ucitajKorisnikeUComboBox(KlijentiComboBox);
            }
            else if (radioButton2.Checked)
            {
                klijenti.ucitajDobavljaceUCombobox(KlijentiComboBox);
            }
        }

        //private void DobavljacRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    KorisnikRadioButton.Checked = false;
        //    klijenti.ucitajDobavljaceUCombobox(KlijentiComboBox);
        //}

        //private void KorisnikRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    DobavljacRadioButton.Checked = false;
        //    korisnici.ucitajKorisnikeUComboBox(KlijentiComboBox);
        //}

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
            if (jedMereReversTextBox.Text == "" || UkupnoTextBox.Text == "")
            {
                MessageBox.Show("Sva polja za unos reversa su obavezna!");
                return;
            }
            
            if (true)
            {

            }
            kki.DodajRevers(jedMereReversTextBox.Text, ulaz, izlaz, RobaComboBox.SelectedItem as Roba, UkupnoTextBox.Text);
        }

        private void DodajStavkubButton_Click(object sender, EventArgs e)
        {
            if (JedMereStavkaTextBox.Text == "" || UkupnaCenaTextBox.Text == "")
            {
                MessageBox.Show("Sva polja su obavezno za dodavanje stavke!");
                return;
            }
            kki.dodajStavku(comboBox1.SelectedItem as Roba, (int)KolicinaNumericUpDown.Value, JedMereStavkaTextBox.Text, UkupnaCenaTextBox.Text);
        }

        private void OdustanibButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SacuvajButton_Click(object sender, EventArgs e)
        {
            if (MestoTextBox.Text == "" || RobuPrimioTextBox.Text == "")
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }
            if (kki.sacuvajPrijemnicu(MestoTextBox.Text, dateTimePicker1.Value, RobuPrimioTextBox.Text, KlijentiComboBox.SelectedItem as OpstiDomenskiObjekat))
            {
                this.Dispose();
            }
        }
    }
}
