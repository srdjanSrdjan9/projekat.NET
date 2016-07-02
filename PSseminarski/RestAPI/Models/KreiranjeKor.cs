using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class KreiranjeKor
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        
        public KreiranjeKor() { }
    }
}