using KontrolerAplikacioneLogike;
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
using Model;

namespace Forme
{
    public partial class PretragaProizvoda : Form
    {
        DokumentiKontroler kki = new DokumentiKontroler();

        public PretragaProizvoda()
        {
            InitializeComponent();
            kki.ucitajRobuUComboBox(RobaComboBox);
        }

        private void DajStanjeButton_Click(object sender, EventArgs e)
        {
            kki.PopuniStanje(RobaComboBox.SelectedItem as Roba, PrimljenoTextBox, ProdatoTextBox);
        }
    }
}
