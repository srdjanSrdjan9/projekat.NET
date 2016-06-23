using KontrolerKorisnickogInterfejsa;
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
        DokumentiKontroler kki = new DokumentiKontroler();
        
        public Homepage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (!kki.poveziSeSaServerom())
            {
                this.Dispose();
            }
            kki.ucitajDokumentaUDataGrid(DokumentiDataGridView);
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

        private void pretragaProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void KreirajPrijemnicuButton_Click(object sender, EventArgs e)
        {
            KreiranjePrijemnice kp = new KreiranjePrijemnice();
            kp.ShowDialog();
        }

        private void KreirajOtpremnicuButton_Click(object sender, EventArgs e)
        {
            KreiranjeOtpremnice otp = new KreiranjeOtpremnice();
            otp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.ucitajDokumentaUDataGrid(DokumentiDataGridView);
        }
    }
}
