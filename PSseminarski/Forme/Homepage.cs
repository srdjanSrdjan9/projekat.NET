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
    public partial class Homepage : Form
    {
        KontrolerKI kki = new KontrolerKI();

        public Homepage()
        {
            InitializeComponent();
            kki.poveziSeSaServerom();
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Korisnici k = new Korisnici();
            k.ShowDialog();
        }

        private void dobavljačiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KreiranjeDobavljaca k = new KreiranjeDobavljaca();
            k.ShowDialog();
        }

        private void kupciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KreiranjeKupca kupac = new KreiranjeKupca();
            kupac.ShowDialog();
        }
    }
}
