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
                            transfer.Uspesnost = so.IzvrsiSo(new Korisnik());
                            transfer.TransferObjekat = so.Lista;
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_korisnika:
                            SOKreirajKorisnika kreiranje = new SOKreirajKorisnika();
                            transfer.Uspesnost = kreiranje.IzvrsiSo(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Brisanje_korisnika:
                            SOBrisanjeKorisnika brisanje = new SOBrisanjeKorisnika();
                            transfer.Uspesnost = brisanje.IzvrsiSo(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Azuriranje_korisnika:
                            SOAzuriranjeKorisnika azuriranje = new SOAzuriranjeKorisnika();
                            transfer.Uspesnost = azuriranje.IzvrsiSo(transfer.TransferObjekat as Korisnik);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_dobavljaca:
                            SOKreiranjeDobavljaca dobavljac = new SOKreiranjeDobavljaca();
                            transfer.Uspesnost = dobavljac.IzvrsiSo(transfer.TransferObjekat as Dobavljac);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_kupca:
                            SOKreiranjeKupca kupac = new SOKreiranjeKupca();
                            transfer.Uspesnost = kupac.IzvrsiSo
                                (transfer.TransferObjekat as Kupac);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_dobavljace:
                            SOVratiDobavljace sovd = new SOVratiDobavljace();
                            transfer.Uspesnost = sovd.IzvrsiSo(new Dobavljac());
                            transfer.TransferObjekat = sovd.Lista;
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_Robu:
                            SOVratiRobu sovr = new SOVratiRobu();
                            transfer.Uspesnost = sovr.IzvrsiSo(new Roba());
                            transfer.TransferObjekat = sovr.Lista;
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_kupce:
                            SOVratiKupce kupci = new SOVratiKupce();
                            transfer.Uspesnost = kupci.IzvrsiSo(new Kupac());
                            transfer.TransferObjekat = kupci.Lista;
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_prijemnice:
                            SOKreiranjePrijemnice prijemnica = new SOKreiranjePrijemnice();
                            transfer.Uspesnost = prijemnica.IzvrsiSo(transfer.TransferObjekat as Prijemnica);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_otpremnice:
                            SOKreiranjeOtpremnice otpr = new SOKreiranjeOtpremnice();
                            transfer.Uspesnost = otpr.IzvrsiSo(transfer.TransferObjekat as Otpremnica);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_dokumenta:
                            SOVratiDokumente dok = new SOVratiDokumente();
                            transfer.Uspesnost = dok.IzvrsiSo(new Otpremnica());
                            transfer.TransferObjekat = dok.Lista;
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
