using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerKorisnickogInterfejsa
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater = new BinaryFormatter();

        public bool poveziSeSaServerom()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 10000);
                tok = klijent.GetStream();
                TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                if (transfer.Operacija == (int)Operacije.Kraj)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #region korisnici
        public List<OpstiDomenskiObjekat> vratiSveKorisnike()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Vrati_korisnike;
            transfer.TransferObjekat = new Korisnik();
            formater.Serialize(tok, transfer);

            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            List <OpstiDomenskiObjekat> korisnici = response.TransferObjekat as List<OpstiDomenskiObjekat>;
            return korisnici;
        }

        public bool azurirajKorisnika(Korisnik k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Azuriranje_korisnika;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public bool sacuvajOtpremnicu(Otpremnica otpremnica)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_otpremnice;
            transfer.TransferObjekat = otpremnica;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public bool sacuvajKorisnika(Korisnik k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_korisnika;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public bool obrisiKorisnika(Korisnik k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Signal = k.KorisnikID;
            transfer.Operacija = (int)Operacije.Brisanje_korisnika;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        #endregion

        #region kupci
        public bool sacuvajKupca(Kupac k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_kupca;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public List<OpstiDomenskiObjekat> vratiKupce()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Vrati_kupce;
            transfer.TransferObjekat = new Kupac();
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.TransferObjekat as List<OpstiDomenskiObjekat>;
        }

        #endregion

        #region dobavljaci
        public bool sacuvajDobavljaca(Dobavljac d)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_dobavljaca;
            transfer.TransferObjekat = d;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public List<OpstiDomenskiObjekat> vratiDobavljace()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Vrati_dobavljace;
            transfer.TransferObjekat = new Dobavljac();
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.TransferObjekat as List<OpstiDomenskiObjekat>;
        }

        #endregion

        public List<OpstiDomenskiObjekat> vratiRobu()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Vrati_Robu;
            transfer.TransferObjekat = new Roba();
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.TransferObjekat as List<OpstiDomenskiObjekat>;
        }

        public List<OpstiDomenskiObjekat> vratiDokumenta()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Vrati_dokumenta;
            transfer.TransferObjekat = new Otpremnica();
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.TransferObjekat as List<OpstiDomenskiObjekat>;
        }

        public bool sacuvajPrijemnicu(Prijemnica p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_prijemnice;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public void zatvori()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }
    }
}
