namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KupciIDobavljaci : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dokuments", "KlijentID", "dbo.Klijents");
            DropForeignKey("dbo.Dokuments", "KlijentID1", "dbo.Klijents");
            DropIndex("dbo.Dokuments", new[] { "KlijentID" });
            DropIndex("dbo.Dokuments", new[] { "KlijentID1" });
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
            
            AddColumn("dbo.Dokuments", "Klijent_DobavljacID", c => c.Long());
            AddColumn("dbo.Dokuments", "Klijent_DobavljacID1", c => c.Long());
            CreateIndex("dbo.Dokuments", "Klijent_DobavljacID");
            CreateIndex("dbo.Dokuments", "Klijent_DobavljacID1");
            AddForeignKey("dbo.Dokuments", "Klijent_DobavljacID", "dbo.Dobavljacs", "DobavljacID");
            AddForeignKey("dbo.Dokuments", "Klijent_DobavljacID1", "dbo.Dobavljacs", "DobavljacID");
            DropTable("dbo.Klijents");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Dokuments", "Klijent_DobavljacID1", "dbo.Dobavljacs");
            DropForeignKey("dbo.Dokuments", "Klijent_DobavljacID", "dbo.Dobavljacs");
            DropIndex("dbo.Dokuments", new[] { "Klijent_DobavljacID1" });
            DropIndex("dbo.Dokuments", new[] { "Klijent_DobavljacID" });
            DropColumn("dbo.Dokuments", "Klijent_DobavljacID1");
            DropColumn("dbo.Dokuments", "Klijent_DobavljacID");
            DropTable("dbo.Kupacs");
            DropTable("dbo.Dobavljacs");
            CreateIndex("dbo.Dokuments", "KlijentID1");
            CreateIndex("dbo.Dokuments", "KlijentID");
            AddForeignKey("dbo.Dokuments", "KlijentID1", "dbo.Klijents", "KlijentID");
            AddForeignKey("dbo.Dokuments", "KlijentID", "dbo.Klijents", "KlijentID");
        }
    }
}
