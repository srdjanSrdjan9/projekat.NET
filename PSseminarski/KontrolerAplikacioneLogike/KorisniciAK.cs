using Model;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerAplikacioneLogike
{
    public class KorisniciAK
    {
        public List<OpstiDomenskiObjekat> vratiKorisnike()
        {
            SOPretraziKorisnike so = new SOPretraziKorisnike();
            so.IzvrsiSo(new Korisnik());
            return so.Lista;
        }

        public bool kreiranjeKorisnika(Korisnik k)
        {
            SOKreirajKorisnika so = new SOKreirajKorisnika();
            return so.IzvrsiSo(k);
        }

        public bool obrisiKorisnika(Korisnik k)
        {
            SOBrisanjeKorisnika brisanje = new SOBrisanjeKorisnika();
            return brisanje.IzvrsiSo(k);
        }

        public bool azurirajKorisnika(Korisnik k)
        {
            SOAzuriranjeKorisnika azuriranje = new SOAzuriranjeKorisnika();
            return azuriranje.IzvrsiSo(k);
        }
    }
}
