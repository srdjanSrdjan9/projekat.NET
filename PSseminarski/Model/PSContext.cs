using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace Model
{
    public class PSContext : DbContext
    {
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Roba> Roba { get; set; }
        public DbSet<StavkaOtpremnice> StavkeOtpremnice { get; set; }
        public DbSet<StavkaPrijemnice> StavkePrijemnice { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Revers> Revers { get; set; }

        public PSContext()
            : base("name = NovaBaza")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<>
        }

        public bool ubaci(OpstiDomenskiObjekat odo)
        {
            try
            {
                string query = "INSERT INTO " + odo.vratiImeTabele() + " " + odo.VrednostZaInsert();
                int rezultat = this.Database.ExecuteSqlCommand(query);
                return rezultat == 1 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
