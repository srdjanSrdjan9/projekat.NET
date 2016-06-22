namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KlijentiSredjeni : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Dokuments", name: "KupacID", newName: "Kupac_KupacID");
            RenameColumn(table: "dbo.Dokuments", name: "DobavljacID", newName: "Dobavljac_DobavljacID");
            RenameColumn(table: "dbo.Dokuments", name: "KorisnikID", newName: "Korisnik_KorisnikID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_KupacID", newName: "IX_Kupac_KupacID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_DobavljacID", newName: "IX_Dobavljac_DobavljacID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_KorisnikID", newName: "IX_Korisnik_KorisnikID");
            DropColumn("dbo.Dokuments", "RedniBroj");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dokuments", "RedniBroj", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Dokuments", name: "IX_Korisnik_KorisnikID", newName: "IX_KorisnikID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_Dobavljac_DobavljacID", newName: "IX_DobavljacID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_Kupac_KupacID", newName: "IX_KupacID");
            RenameColumn(table: "dbo.Dokuments", name: "Korisnik_KorisnikID", newName: "KorisnikID");
            RenameColumn(table: "dbo.Dokuments", name: "Dobavljac_DobavljacID", newName: "DobavljacID");
            RenameColumn(table: "dbo.Dokuments", name: "Kupac_KupacID", newName: "KupacID");
        }
    }
}
