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
using KontrolerKorisnickogInterfejsa;

namespace Forme
{
    public partial class AzuriranjeKorisnika : Form
    {
        Korisnik korisnik = new Korisnik();
        KorisniciKontroler kki = new KorisniciKontroler();

        public AzuriranjeKorisnika(Korisnik k)
        {
            korisnik = k;
            InitializeComponent();
            ImeTextBox.Text = k.Ime;
            PrezimeTextBox.Text = k.Prezime;
            AdresaTextBox.Text = k.Adresa;
            JmbgTextBox.Text = k.Jmbg;
            DatumTextBox.Text = k.DatumRegistrovanja.ToString("dd.MM.yyyy hh:MM:ss");
            DatumTextBox.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AzurirajButton_Click(object sender, EventArgs e)
        {
            kki.azurirajKorisnika(korisnik.KorisnikID, ImeTextBox.Text.Trim(), PrezimeTextBox.Text.Trim(), AdresaTextBox.Text.Trim(), JmbgTextBox.Text.Trim());
            this.Dispose();
        }
    }
}
