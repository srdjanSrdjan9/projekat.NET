namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StavkaOtpremnices", "RobaID", c => c.Int(nullable: false));
            CreateIndex("dbo.StavkaOtpremnices", "RobaID");
            AddForeignKey("dbo.StavkaOtpremnices", "RobaID", "dbo.Robas", "RobaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StavkaOtpremnices", "RobaID", "dbo.Robas");
            DropIndex("dbo.StavkaOtpremnices", new[] { "RobaID" });
            DropColumn("dbo.StavkaOtpremnices", "RobaID");
        }
    }
}
