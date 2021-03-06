﻿using KontrolerKorisnickogInterfejsa;
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
    public partial class KreiranjeOtpremnice : Form
    {
        DokumentiKontroler kki = new DokumentiKontroler();
        KlijentiKontroler klijenti = new KlijentiKontroler();

        public KreiranjeOtpremnice()
        {
            InitializeComponent();
            klijenti.ucitajKupceUComboBox(KupciComboBox);
            kki.ucitajRobuUComboBox(RobaComboBox);
            dataGridView1.DataSource = kki.stavkeOtpr;
        }

        private void DodajStavkuButton_Click(object sender, EventArgs e)
        {
            int JedCena;
            if (!Int32.TryParse(JedinicnaCenaTextBox.Text, out JedCena))
            {
                MessageBox.Show("Jedinicna cena mora biti broj!");
                return;
            }
            UkupnoTextBox.Text = (JedCena * KolicinaNumericUpDown.Value).ToString();
            kki.dodajStavkuOtpremnice(JedinicaMereTextBox.Text, (int)KolicinaNumericUpDown.Value, JedinicnaCenaTextBox.Text,RobaComboBox.SelectedItem as Roba);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SacuvajButton_Click(object sender, EventArgs e)
        {
            if (MestoTextBox.Text == "")
            {
                MessageBox.Show("Mesto mora biti uneto!!!");
                return;
            }
            if (kki.sacuvajOtpremnicu(MestoTextBox.Text, dateTimePicker1.Value, KupciComboBox.SelectedItem as Kupac))
            {
                this.Dispose();
            }
        }
    }
}
