using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemskeOperacije;

namespace KontrolerAplikacioneLogike
{
    public class KlijentiAK
    {
        public bool kreirajKupca(Kupac k)
        {
            SOKreiranjeKupca so = new SOKreiranjeKupca();
            return so.izvrsi(k);
        }

        public bool kreirajDobavljaca(Dobavljac d)
        {
            SOKreiranjeDobavljaca dobavljac = new SOKreiranjeDobavljaca();
            return dobavljac.IzvrsiSo(d);
        }

        public List<OpstiDomenskiObjekat> vratiDobavljace()
        {
            SOVratiKupce sovd = new SOVratiKupce();
            sovd.IzvrsiSo(new Dobavljac());
            return sovd.Lista;
        }

        public List<OpstiDomenskiObjekat> vratiKupce()
        {
            SOVratiKupce sovd = new SOVratiKupce();
            sovd.IzvrsiSo(new Kupac());
            return sovd.Lista;
        }
    }
}
