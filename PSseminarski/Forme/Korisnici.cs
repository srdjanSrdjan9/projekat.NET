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
    public partial class Korisnici : Form
    {
        KontrolerKI kki = new KontrolerKI();

        public Korisnici()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Korisnici_Load(object sender, EventArgs e)
        {
            kki.dajKorisnike(dataGridView1);
        }

        private void DodajKorisnikaButton_Click(object sender, EventArgs e)
        {
            KreiranjeKorisnika k = new KreiranjeKorisnika();
            k.ShowDialog();
        }

        private void OsveziButton_Click(object sender, EventArgs e)
        {
            kki.dajKorisnike(dataGridView1);
        }

        private void BrisanjeKorisnikaButton_Click(object sender, EventArgs e)
        {
            kki.ObrisiKorisnika(kki.korisnici.ElementAt(dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0])).KorisnikID);
        }

        private void AzurirajKorisnikabButton_Click(object sender, EventArgs e)
        {
            AzuriranjeKorisnika a = new AzuriranjeKorisnika(kki.korisnici.ElementAt(dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0])));
            a.ShowDialog();
        }
    }
}
