using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolerKorisnickogInterfejsa
{
    public abstract class ApstraktniKontrolerKI
    {
        public static Komunikacija k = new Komunikacija();

        public bool poveziSeSaServerom()
        {
            bool rezultat = k.poveziSeSaServerom();
            if (rezultat)
            {
                MessageBox.Show("Uspesna konekcija!");
                return true;
            }
            else
            {
                MessageBox.Show("Neuspesna konekcija!");
                return false;
            }
        }
    }
}
