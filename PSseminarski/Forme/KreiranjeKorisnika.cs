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
    public partial class KreiranjeKorisnika : Form
    {
        KorisniciKontroler kki = new KorisniciKontroler();

        public KreiranjeKorisnika()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SacuvajButton_Click(object sender, EventArgs e)
        {
            if (
            kki.sacuvajKorisnika(ImeTextBox.Text.Trim(), PrezimeTextBox.Text.Trim(), AdresaTextBox.Text.Trim(), JmbgTextBox.Text.Trim()) != null)
            {
                this.Dispose();
            }
            else
            {
                return;
            }
        }
    }
}
