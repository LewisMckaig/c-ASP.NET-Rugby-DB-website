namespace SimplyRugby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id1" });
            AlterColumn("dbo.TrainingRecords", "nonPlayer_id1", c => c.Int());
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id1");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id1" });
            AlterColumn("dbo.TrainingRecords", "nonPlayer_id1", c => c.Int(nullable: false));
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id1");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers", "id", cascadeDelete: true);
        }
    }
}
