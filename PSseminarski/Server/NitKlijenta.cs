using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SistemskeOperacije;

namespace Server
{
    public class NitKlijenta
    {
        BinaryFormatter formater;
        NetworkStream tok;
        List<TransferKlasa> klijenti = new List<TransferKlasa>();


        public NitKlijenta(NetworkStream tok, List<TransferKlasa> klijenti)
        {
            formater = new BinaryFormatter();
            this.tok = tok;
            this.klijenti = klijenti;
            ThreadStart ts = obradaPodataka;
            Thread nit = new Thread(ts);
            nit.Start();


        }

        private void obradaPodataka()
        {
            try
            {
                int operacija = 0;
                while (operacija != (int)Operacije.Kraj)
                {

                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                    operacija = transfer.Operacija;
                    switch (transfer.Operacija)
                    {
                        case (int)Operacije.Vrati_korisnike:
                            SOPretraziKorisnike so = new SOPretraziKorisnike();
                            try
                            {
                                transfer.TransferObjekat = so.vratiKorisnike();
                                transfer.Uspesnost = true;
                            }
                            catch (Exception)
                            {
                                transfer.Uspesnost = false;
                            }
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_korisnika:
                            SOKreirajKorisnika kreiranje = new SOKreirajKorisnika();
                            transfer.Uspesnost = kreiranje.sacuvajKorisnika(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Brisanje_korisnika:
                            SOBrisanjeKorisnika brisanje = new SOBrisanjeKorisnika();
                            transfer.Uspesnost = brisanje.obrisiKorisnika(transfer.Signal);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Azuriranje_korisnika:
                            SOAzuriranjeKorisnika azuriranje = new SOAzuriranjeKorisnika();
                            transfer.Uspesnost = azuriranje.azurirajKorisnika(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;
                        case ((int)Operacije.Kraj):
                            Console.WriteLine("Hvala na konekciji!");
                            foreach (TransferKlasa t in klijenti)
                            {
                                if (t.Signal == transfer.Signal)
                                {
                                    klijenti.Remove(t);
                                    break;
                                }
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Prekid niti:" + ex.Message);
            }
        }
    }
}
