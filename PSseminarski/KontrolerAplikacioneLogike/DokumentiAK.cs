﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SistemskeOperacije;

namespace KontrolerAplikacioneLogike
{
    public class DokumentiAK
    {
        public bool sacuvajPrijemnicu(Prijemnica p)
        {
            SOKreiranjePrijemnice prijemnica = new SOKreiranjePrijemnice();
            return prijemnica.IzvrsiSo(p);
        }

        public bool sacuvajOtpremnicu(Otpremnica o)
        {
            SOKreiranjeOtpremnice otpr = new SOKreiranjeOtpremnice();
            return otpr.IzvrsiSo(o);
        }

        public List<OpstiDomenskiObjekat> vratiDokumenta()
        {
            SOVratiDokumente dok = new SOVratiDokumente();
            dok.IzvrsiSo(new Prijemnica());
            return dok.Lista;
        }

        public bool sacuvajRevers(List<Revers> r)
        {
            if (r == null)
            {
                return true;
            }
            int count = 0;
            SOKreiranjeReversa so = new SOKreiranjeReversa();
            r.ForEach(c =>
            {
                if (so.IzvrsiSo(c))
                {
                    count++;
                }
            });

            if (count == r.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
