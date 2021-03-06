﻿using Model;
using RestAPI.Models;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Korisnici")]
    public class KorisniciController : ApiController
    {
        [HttpPost]
        [Route("kreiranje")]
        public IHttpActionResult createUser([FromBody]KreiranjeKor k)
        {
            SOKreirajKorisnika so = new SOKreirajKorisnika();
            Korisnik kor = new Korisnik()
            {
                Ime = k.Ime,
                Prezime = k.Prezime,
                Adresa = k.Adresa,
                Jmbg = k.Jmbg
            };
            if (so.IzvrsiSo(kor))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("brisanje")]
        public IHttpActionResult deleteUser([FromBody]Korisnik k)
        {
            SOBrisanjeKorisnika sob = new SOBrisanjeKorisnika();
            if (sob.IzvrsiSo(k))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("azuriranje")]
        public IHttpActionResult updateUser([FromBody]Korisnik k)
        {
            SOAzuriranjeKorisnika sob = new SOAzuriranjeKorisnika();
            if (sob.IzvrsiSo(k))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("dajSve")]
        public IEnumerable<OpstiDomenskiObjekat> ucitajKorisnike()
        {
            SOPretraziKorisnike sop = new SOPretraziKorisnike();
            sop.IzvrsiSo(new Korisnik());
            return sop.Lista;
        }
    }
}
