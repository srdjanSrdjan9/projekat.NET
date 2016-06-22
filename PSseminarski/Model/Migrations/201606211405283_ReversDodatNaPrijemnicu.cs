namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReversDodatNaPrijemnicu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dokuments", "ReversID", "dbo.Revers");
            DropIndex("dbo.Dokuments", new[] { "ReversID" });
            AddColumn("dbo.Revers", "Prijemnica_DokumentID", c => c.Long());
            CreateIndex("dbo.Revers", "Prijemnica_DokumentID");
            AddForeignKey("dbo.Revers", "Prijemnica_DokumentID", "dbo.Dokuments", "DokumentID");
            DropColumn("dbo.Dokuments", "ReversID");
            DropColumn("dbo.StavkaOtpremnices", "KlasaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StavkaOtpremnices", "KlasaID", c => c.Int(nullable: false));
            AddColumn("dbo.Dokuments", "ReversID", c => c.Long());
            DropForeignKey("dbo.Revers", "Prijemnica_DokumentID", "dbo.Dokuments");
            DropIndex("dbo.Revers", new[] { "Prijemnica_DokumentID" });
            DropColumn("dbo.Revers", "Prijemnica_DokumentID");
            CreateIndex("dbo.Dokuments", "ReversID");
            AddForeignKey("dbo.Dokuments", "ReversID", "dbo.Revers", "ReversID");
        }
    }
}
