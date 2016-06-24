namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dobavljacs",
                c => new
                    {
                        DobavljacID = c.Long(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Pib = c.String(),
                        MaticniBroj = c.String(),
                    })
                .PrimaryKey(t => t.DobavljacID);
            
            CreateTable(
                "dbo.Dokuments",
                c => new
                    {
                        DokumentID = c.Long(nullable: false, identity: true),
                        DatumIzdavanja = c.DateTime(nullable: false),
                        Mesto = c.String(),
                        RobuPrimio = c.String(),
                        KupacID = c.Long(),
                        NacinOtpreme = c.String(maxLength: 50),
                        KorisnikID = c.Long(),
                        DobavljacID = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DokumentID)
                .ForeignKey("dbo.Kupacs", t => t.KupacID)
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacID)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikID)
                .Index(t => t.KupacID)
                .Index(t => t.KorisnikID)
                .Index(t => t.DobavljacID);
            
            CreateTable(
                "dbo.Kupacs",
                c => new
                    {
                        KupacID = c.Long(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Pib = c.String(),
                        MaticniBroj = c.String(),
                    })
                .PrimaryKey(t => t.KupacID);
            
            CreateTable(
                "dbo.StavkaOtpremnices",
                c => new
                    {
                        DokumentID = c.Long(nullable: false),
                        RedniBrojStavke = c.Int(nullable: false),
                        JedCena = c.Double(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        UkupnaCena = c.Double(nullable: false),
                        JedMere = c.String(),
                        RobaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DokumentID, t.RedniBrojStavke })
                .ForeignKey("dbo.Robas", t => t.RobaID)
                .ForeignKey("dbo.Dokuments", t => t.DokumentID)
                .Index(t => t.DokumentID)
                .Index(t => t.RobaID);
            
            CreateTable(
                "dbo.Robas",
                c => new
                    {
                        RobaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.RobaID);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        KorisnikID = c.Long(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Adresa = c.String(),
                        Jmbg = c.String(maxLength: 13),
                        DatumRegistrovanja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnikID);
            
            CreateTable(
                "dbo.StavkaPrijemnices",
                c => new
                    {
                        DokumentID = c.Long(nullable: false),
                        RedniBrojStavke = c.Int(nullable: false),
                        JedCena = c.Double(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        UkupnaCena = c.Double(nullable: false),
                        JedMere = c.String(),
                        RobaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DokumentID, t.RedniBrojStavke })
                .ForeignKey("dbo.Robas", t => t.RobaID)
                .ForeignKey("dbo.Dokuments", t => t.DokumentID)
                .Index(t => t.DokumentID)
                .Index(t => t.RobaID);
            
            CreateTable(
                "dbo.Revers",
                c => new
                    {
                        ReversID = c.Long(nullable: false, identity: true),
                        JedMere = c.String(),
                        RedniBroj = c.Int(nullable: false),
                        Ulaz = c.Int(nullable: false),
                        Izlaz = c.Int(nullable: false),
                        Ukupno = c.Int(nullable: false),
                        RobaID = c.Int(nullable: false),
                        DokumentID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ReversID)
                .ForeignKey("dbo.Dokuments", t => t.DokumentID)
                .ForeignKey("dbo.Robas", t => t.RobaID)
                .Index(t => t.RobaID)
                .Index(t => t.DokumentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revers", "RobaID", "dbo.Robas");
            DropForeignKey("dbo.Revers", "DokumentID", "dbo.Dokuments");
            DropForeignKey("dbo.StavkaPrijemnices", "DokumentID", "dbo.Dokuments");
            DropForeignKey("dbo.StavkaPrijemnices", "RobaID", "dbo.Robas");
            DropForeignKey("dbo.Dokuments", "KorisnikID", "dbo.Korisniks");
            DropForeignKey("dbo.Dokuments", "DobavljacID", "dbo.Dobavljacs");
            DropForeignKey("dbo.StavkaOtpremnices", "DokumentID", "dbo.Dokuments");
            DropForeignKey("dbo.StavkaOtpremnices", "RobaID", "dbo.Robas");
            DropForeignKey("dbo.Dokuments", "KupacID", "dbo.Kupacs");
            DropIndex("dbo.Revers", new[] { "DokumentID" });
            DropIndex("dbo.Revers", new[] { "RobaID" });
            DropIndex("dbo.StavkaPrijemnices", new[] { "RobaID" });
            DropIndex("dbo.StavkaPrijemnices", new[] { "DokumentID" });
            DropIndex("dbo.StavkaOtpremnices", new[] { "RobaID" });
            DropIndex("dbo.StavkaOtpremnices", new[] { "DokumentID" });
            DropIndex("dbo.Dokuments", new[] { "DobavljacID" });
            DropIndex("dbo.Dokuments", new[] { "KorisnikID" });
            DropIndex("dbo.Dokuments", new[] { "KupacID" });
            DropTable("dbo.Revers");
            DropTable("dbo.StavkaPrijemnices");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Robas");
            DropTable("dbo.StavkaOtpremnices");
            DropTable("dbo.Kupacs");
            DropTable("dbo.Dokuments");
            DropTable("dbo.Dobavljacs");
        }
    }
}
