﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Model
{
    public class PSContext:DbContext
    {
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Roba> Roba { get; set; }
        public DbSet<StavkaOtpremnice> StavkeOtpremnice { get; set; }
        public DbSet<StavkaPrijemnice> StavkePrijemnice { get; set; }

        public PSContext()
            : base("name = PSseminarski")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
