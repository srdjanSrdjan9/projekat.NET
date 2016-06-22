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
                        case (int)Operacije.Kreiranje_dobavljaca:
                            SOKreiranjeDobavljaca dobavljac = new SOKreiranjeDobavljaca();
                            transfer.Uspesnost = dobavljac.sacuvajDobavljaca(transfer.TransferObjekat as Dobavljac);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_kupca:
                            SOKreiranjeKupca kupac = new SOKreiranjeKupca();
                            transfer.Uspesnost = kupac.sacuvajKupca
                                (transfer.TransferObjekat as Kupac);
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_dobavljace:
                            SOVratiDobavljace sovd = new SOVratiDobavljace();
                            try
                            {
                                transfer.TransferObjekat = sovd.vratiSveDobavljace();
                                transfer.Uspesnost = true;
                            }
                            catch (Exception)
                            {
                                transfer.Uspesnost = false;
                            }
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_Robu:
                            SOVratiRobu sovr = new SOVratiRobu();
                            try
                            {
                                transfer.TransferObjekat = sovr.vratiProizvode();
                                transfer.Uspesnost = true;
                            }
                            catch (Exception)
                            {
                                transfer.Uspesnost = false;
                            }
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Vrati_kupce:
                            SOVratiKupce kupci = new SOVratiKupce();
                            try
                            {
                                transfer.TransferObjekat = kupci.vratiKupce();
                                transfer.Uspesnost = true;
                            }
                            catch (Exception)
                            {
                                transfer.Uspesnost = false;
                            }
                            formater.Serialize(tok, transfer);
                            break;
                        case (int)Operacije.Kreiranje_prijemnice:
                            SOKreiranjePrijemnice prijemnica = new SOKreiranjePrijemnice();
                            transfer.Uspesnost = prijemnica.KreirajOtpremnicu(transfer.TransferObjekat as Prijemnica);
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
