using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using SistemskeOperacije;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Otpremnice")]
    public class OtpremniceController : ApiController
    {
        [HttpPost]
        [Route("kreiranje")]
        public IHttpActionResult createOtpremnica([FromBody]Otpremnica o)
        {
            SOKreiranjeOtpremnice sok = new SOKreiranjeOtpremnice();
            if (sok.IzvrsiSo(o))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("dajRobu")]
        public IEnumerable<OpstiDomenskiObjekat> getRoba()
        {
            SOVratiRobu sov = new SOVratiRobu();
            sov.IzvrsiSo(new Roba());
            return sov.Lista;
        }

        [HttpGet]
        [Route("dajKupce")]
        public IEnumerable<OpstiDomenskiObjekat> getKupci()
        {
            SOVratiKupce sov = new SOVratiKupce();
            sov.IzvrsiSo(new Kupac());
            return sov.Lista;
        }
    }
}
