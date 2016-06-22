namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IzbaceniRBnaDokumentima : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dokuments", "BrojOtpremnice");
            DropColumn("dbo.Dokuments", "BrojPrijemnice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dokuments", "BrojPrijemnice", c => c.Int());
            AddColumn("dbo.Dokuments", "BrojOtpremnice", c => c.Int());
        }
    }
}
