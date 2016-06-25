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
using KontrolerAplikacioneLogike;

namespace Server
{
    public class NitKlijenta
    {
        BinaryFormatter formater;
        NetworkStream tok;
        List<TransferKlasa> klijenti = new List<TransferKlasa>();

        KorisniciAK korisnici = new KorisniciAK();
        KlijentiAK kl = new KlijentiAK();
        RobaAK roba = new RobaAK();
        DokumentiAK dokumenti = new DokumentiAK();

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
                        case (int)Operacije.Kreiraj_Revers:
                            transfer.Uspesnost = dokumenti.sacuvajRevers(transfer.TransferObjekat as List<Revers>);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Pretrazivanje_proizvoda:
                            transfer.TransferObjekat = roba.pretraziProizvode(transfer.TransferObjekat as Roba);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_korisnike:
                            transfer.TransferObjekat = korisnici.vratiKorisnike();
                            transfer.Uspesnost = true;
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Kreiranje_korisnika:
                            transfer.Uspesnost = korisnici.kreiranjeKorisnika(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Brisanje_korisnika:
                            transfer.Uspesnost = korisnici.obrisiKorisnika(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Azuriranje_korisnika:
                            transfer.Uspesnost = korisnici.azurirajKorisnika(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Kreiranje_dobavljaca:
                            transfer.Uspesnost = kl.kreirajDobavljaca(transfer.TransferObjekat as Dobavljac);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Kreiranje_kupca:
                            transfer.Uspesnost = kl.kreirajKupca
                                (transfer.TransferObjekat as Kupac);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Vrati_dobavljace:
                            transfer.Uspesnost = true;
                            transfer.TransferObjekat = kl.vratiDobavljace();
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Vrati_Robu:
                            transfer.Uspesnost = true;
                            transfer.TransferObjekat = roba.vratiProizvode(null);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Vrati_kupce:
                            transfer.Uspesnost = true;
                            transfer.TransferObjekat = kl.vratiKupce();
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Kreiranje_prijemnice:
                            transfer.Uspesnost = dokumenti.sacuvajPrijemnicu(transfer.TransferObjekat as Prijemnica);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Kreiranje_otpremnice:
                            transfer.Uspesnost = dokumenti.sacuvajOtpremnicu(transfer.TransferObjekat as Otpremnica);
                            formater.Serialize(tok, transfer);
                            break;

                        case (int)Operacije.Vrati_dokumenta:
                            transfer.TransferObjekat = dokumenti.vratiDokumenta();
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
