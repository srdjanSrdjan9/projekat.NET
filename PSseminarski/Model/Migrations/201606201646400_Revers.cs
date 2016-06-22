namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revers : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.ReversID)
                .ForeignKey("dbo.Robas", t => t.RobaID)
                .Index(t => t.RobaID);
            
            AddColumn("dbo.Dokuments", "KorisnikID", c => c.Long());
            AddColumn("dbo.Dokuments", "ReversID", c => c.Long());
            CreateIndex("dbo.Dokuments", "KorisnikID");
            CreateIndex("dbo.Dokuments", "ReversID");
            AddForeignKey("dbo.Dokuments", "KorisnikID", "dbo.Korisniks", "KorisnikID");
            AddForeignKey("dbo.Dokuments", "ReversID", "dbo.Revers", "ReversID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dokuments", "ReversID", "dbo.Revers");
            DropForeignKey("dbo.Revers", "RobaID", "dbo.Robas");
            DropForeignKey("dbo.Dokuments", "KorisnikID", "dbo.Korisniks");
            DropIndex("dbo.Revers", new[] { "RobaID" });
            DropIndex("dbo.Dokuments", new[] { "ReversID" });
            DropIndex("dbo.Dokuments", new[] { "KorisnikID" });
            DropColumn("dbo.Dokuments", "ReversID");
            DropColumn("dbo.Dokuments", "KorisnikID");
            DropTable("dbo.Revers");
        }
    }
}
