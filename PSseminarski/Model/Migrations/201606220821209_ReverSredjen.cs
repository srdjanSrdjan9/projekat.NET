namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReverSredjen : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Revers", new[] { "RobaID" });
            RenameColumn(table: "dbo.Revers", name: "RobaID", newName: "Roba_RobaID");
            AlterColumn("dbo.Revers", "Roba_RobaID", c => c.Int());
            CreateIndex("dbo.Revers", "Roba_RobaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Revers", new[] { "Roba_RobaID" });
            AlterColumn("dbo.Revers", "Roba_RobaID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Revers", name: "Roba_RobaID", newName: "RobaID");
            CreateIndex("dbo.Revers", "RobaID");
        }
    }
}
