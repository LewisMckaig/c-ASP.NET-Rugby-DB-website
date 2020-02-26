namespace SimplyRugby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteduplicateid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id" });
            AddColumn("dbo.TrainingRecords", "nonPlayer_id1", c => c.Int(nullable: false));
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id1");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers", "id", cascadeDelete: true);
            DropColumn("dbo.TrainingRecords", "coachID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingRecords", "coachID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id1" });
            DropColumn("dbo.TrainingRecords", "nonPlayer_id1");
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id", "dbo.nonPlayers", "id", cascadeDelete: true);
        }
    }
}
