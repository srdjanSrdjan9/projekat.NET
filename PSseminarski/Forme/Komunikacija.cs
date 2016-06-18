using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Forme
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

        public bool sacuvajKorisnika(Korisnik k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kreiranje_korisnika;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
        }

        public bool obrisiKorisnika(long id)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Signal = id;
            transfer.Operacija = (int)Operacije.Brisanje_korisnika;
            formater.Serialize(tok, transfer);
            TransferKlasa response = formater.Deserialize(tok) as TransferKlasa;
            return response.Uspesnost;
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

        public void zatvori()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }
    }
}
