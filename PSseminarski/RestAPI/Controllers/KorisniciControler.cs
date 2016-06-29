using Model;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class KorisniciControler : ApiController
    {
        // GET api/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/kreiranjeKorisnika
        [Route("kreiranjeKorisnika")]
        public IHttpActionResult Post([FromBody]Korisnik k)
        {
            SOKreirajKorisnika so = new SOKreirajKorisnika();
            if (so.IzvrsiSo(k))
            {
                return Ok("Korisnik eje uspesno sacuvan!");
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
