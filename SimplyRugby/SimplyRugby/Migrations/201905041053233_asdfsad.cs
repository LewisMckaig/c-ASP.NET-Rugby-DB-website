namespace SimplyRugby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfsad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id1" });
            AlterColumn("dbo.TrainingRecords", "nonPlayer_id", c => c.Int(nullable: false));
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id", "dbo.nonPlayers", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id1", "dbo.nonPlayers");
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id1" });
            AlterColumn("dbo.TrainingRecords", "nonPlayer_id", c => c.Int());
            CreateIndex("dbo.TrainingRecords", "nonPlayer_id");
            AddForeignKey("dbo.TrainingRecords", "nonPlayer_id", "dbo.nonPlayers", "id");
        }
    }
}
