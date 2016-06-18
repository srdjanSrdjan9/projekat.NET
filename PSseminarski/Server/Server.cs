using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        BinaryFormatter formater = new BinaryFormatter();
        Socket soket;
        NetworkStream tok;
        int brojac = 1;
        List<TransferKlasa> klijenti = new List<TransferKlasa>();


        public void pokreniserver()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress adresa = IPAddress.Parse("127.0.0.1");
            soket.Bind(new IPEndPoint(IPAddress.Any, 10000));
            Console.WriteLine("Server je uspesno startovan!");
            //Thread krajNit = new Thread(new ThreadStart(kraj));
            //krajNit.Start();
            obradiKlijenta();
        }

        //private void kraj()
        //{
        //    Console.WriteLine("Broj klijenta kojeg zelis da ugasis?");
        //    string prihvati = Console.ReadLine();
        //    int brojKlijenta = Convert.ToInt32(prihvati);
        //    foreach (TransferKlasa t in klijenti)
        //    {
        //        if (t.Signal == brojKlijenta)
        //        {
        //            (t.TransferObjekat as Socket).Close();
        //            klijenti.Remove(t);
        //            break;
        //        }
        //    }
        //}

        private void obradiKlijenta()
        {
            soket.Listen(5);
            while (true)
            {
                Socket klijent = soket.Accept();
                tok = new NetworkStream(klijent);
                TransferKlasa transfer = new TransferKlasa();
                if (klijenti.Count == 10)
                {
                    transfer.Operacija = (int)Operacije.Kraj;
                    formater.Serialize(tok, transfer);
                    continue;
                }
                TransferKlasa transferObjekat = new TransferKlasa();
                transferObjekat.TransferObjekat = klijent;
                transferObjekat.Signal = brojac;
                klijenti.Add(transferObjekat);
                transfer.Signal = brojac;
                formater.Serialize(tok, transfer);
                brojac++;
                NitKlijenta nit = new NitKlijenta(tok, klijenti);

            }
        }
        static void Main(string[] args)
        {
            Server s = new Server();
            s.pokreniserver();
        }
    }
}
