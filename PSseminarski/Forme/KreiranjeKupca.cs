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
    public partial class KreiranjeKupca : Form
    {
        KontrolerKI kki = new KontrolerKI();

        public KreiranjeKupca()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SacuvajButton_Click(object sender, EventArgs e)
        {
            if (kki.sacuvajKupca(NazivTextBox.Text.Trim(), PibTextBox.Text.Trim(), MaticniBrojTextBox.Text.Trim(), AdresaTextBox.Text.Trim()) == true)
            {
                this.Dispose();
            }
        }
    }
}
