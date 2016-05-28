namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dokuments",
                c => new
                    {
                        DokumentID = c.Long(nullable: false, identity: true),
                        DatumIzdavanja = c.DateTime(nullable: false),
                        Mesto = c.String(),
                        RobuPrimio = c.String(),
                        RedniBroj = c.Int(nullable: false),
                        BrojOtpremnice = c.Int(),
                        KlijentID = c.Long(),
                        NacinOtpreme = c.String(maxLength: 50),
                        BrojPrijemnice = c.Int(),
                        KlijentID1 = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DokumentID)
                .ForeignKey("dbo.Klijents", t => t.KlijentID)
                .ForeignKey("dbo.Klijents", t => t.KlijentID1)
                .Index(t => t.KlijentID)
                .Index(t => t.KlijentID1);
            
            CreateTable(
                "dbo.Klijents",
                c => new
                    {
                        KlijentID = c.Long(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Pib = c.String(),
                        MaticniBroj = c.String(),
                    })
                .PrimaryKey(t => t.KlijentID);
            
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
                        KlasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DokumentID, t.RedniBrojStavke })
                .ForeignKey("dbo.Dokuments", t => t.DokumentID)
                .Index(t => t.DokumentID);
            
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
                .ForeignKey("dbo.Dokuments", t => t.DokumentID)
                .ForeignKey("dbo.Robas", t => t.RobaID)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StavkaPrijemnices", "RobaID", "dbo.Robas");
            DropForeignKey("dbo.StavkaPrijemnices", "DokumentID", "dbo.Dokuments");
            DropForeignKey("dbo.Dokuments", "KlijentID1", "dbo.Klijents");
            DropForeignKey("dbo.StavkaOtpremnices", "DokumentID", "dbo.Dokuments");
            DropForeignKey("dbo.Dokuments", "KlijentID", "dbo.Klijents");
            DropIndex("dbo.StavkaPrijemnices", new[] { "RobaID" });
            DropIndex("dbo.StavkaPrijemnices", new[] { "DokumentID" });
            DropIndex("dbo.StavkaOtpremnices", new[] { "DokumentID" });
            DropIndex("dbo.Dokuments", new[] { "KlijentID1" });
            DropIndex("dbo.Dokuments", new[] { "KlijentID" });
            DropTable("dbo.Korisniks");
            DropTable("dbo.Robas");
            DropTable("dbo.StavkaPrijemnices");
            DropTable("dbo.StavkaOtpremnices");
            DropTable("dbo.Klijents");
            DropTable("dbo.Dokuments");
        }
    }
}
