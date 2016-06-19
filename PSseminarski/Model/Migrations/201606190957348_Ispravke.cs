namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ispravke : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dokuments", "Klijent_DobavljacID1", "dbo.Dobavljacs");
            DropIndex("dbo.Dokuments", new[] { "Klijent_DobavljacID1" });
            RenameColumn(table: "dbo.Dokuments", name: "Klijent_DobavljacID", newName: "DobavljacID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_Klijent_DobavljacID", newName: "IX_DobavljacID");
            AddColumn("dbo.Dokuments", "KupacID", c => c.Long());
            CreateIndex("dbo.Dokuments", "KupacID");
            AddForeignKey("dbo.Dokuments", "KupacID", "dbo.Kupacs", "KupacID");
            DropColumn("dbo.Dokuments", "KlijentID");
            DropColumn("dbo.Dokuments", "KlijentID1");
            DropColumn("dbo.Dokuments", "Klijent_DobavljacID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dokuments", "Klijent_DobavljacID1", c => c.Long());
            AddColumn("dbo.Dokuments", "KlijentID1", c => c.Long());
            AddColumn("dbo.Dokuments", "KlijentID", c => c.Long());
            DropForeignKey("dbo.Dokuments", "KupacID", "dbo.Kupacs");
            DropIndex("dbo.Dokuments", new[] { "KupacID" });
            DropColumn("dbo.Dokuments", "KupacID");
            RenameIndex(table: "dbo.Dokuments", name: "IX_DobavljacID", newName: "IX_Klijent_DobavljacID");
            RenameColumn(table: "dbo.Dokuments", name: "DobavljacID", newName: "Klijent_DobavljacID");
            CreateIndex("dbo.Dokuments", "Klijent_DobavljacID1");
            AddForeignKey("dbo.Dokuments", "Klijent_DobavljacID1", "dbo.Dobavljacs", "DobavljacID");
        }
    }
}
