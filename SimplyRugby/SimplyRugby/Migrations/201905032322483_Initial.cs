namespace SimplyRugby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.GameRecords",
                 c => new
                 {
                     id = c.Int(nullable: false, identity: true),
                     name = c.String(nullable: false),
                     info = c.String(nullable: false),
                     firstHalf = c.String(nullable: false),
                     secondHalf = c.String(nullable: false),
                     coachID = c.Int(nullable: false),
                 })
                 .PrimaryKey(t => t.id)
                 .ForeignKey("dbo.nonPlayers", t => t.coachID, cascadeDelete: true)
                 .Index(t => t.coachID);

            CreateTable(
                "dbo.nonPlayers",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    fName = c.String(nullable: false),
                    lName = c.String(nullable: false),
                    dob = c.DateTime(nullable: false),
                    address = c.String(nullable: false),
                    postCode = c.String(nullable: false, maxLength: 8),
                    phone = c.String(nullable: false),
                    email = c.String(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Guardians",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    fName = c.String(nullable: false),
                    lName = c.String(nullable: false),
                    address = c.String(nullable: false),
                    phone = c.String(nullable: false),
                    relation = c.String(nullable: false),
                    playerID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Players", t => t.playerID, cascadeDelete: true)
                .Index(t => t.playerID);

            CreateTable(
                "dbo.Players",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    fName = c.String(nullable: false),
                    lName = c.String(nullable: false),
                    dob = c.DateTime(nullable: false),
                    address = c.String(),
                    postCode = c.String(nullable: false, maxLength: 8),
                    phoneNum = c.String(nullable: false),
                    email = c.String(nullable: false),
                    doctor = c.String(nullable: false),
                    position = c.String(nullable: false),
                    healthissues = c.String(nullable: false),
                    team = c.String(nullable: false),
                    trainingID = c.Int(nullable: false),
                    tr_id = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TrainingRecords", t => t.tr_id)
                .Index(t => t.tr_id);

            CreateTable(
                "dbo.TrainingRecords",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    coachId = c.Int(nullable: false),
                    date = c.DateTime(nullable: false),
                    location = c.String(nullable: false),
                    description = c.String(nullable: false),
                    accidents = c.String(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.nonPlayers", t => t.coachId, cascadeDelete: true)
                .Index(t => t.coachId);

            CreateTable(
                "dbo.Skills",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    standard = c.Int(nullable: false),
                    spin = c.Int(nullable: false),
                    pop = c.Int(nullable: false),
                    front = c.Int(nullable: false),
                    rear = c.Int(nullable: false),
                    side = c.Int(nullable: false),
                    scrabble = c.Int(nullable: false),
                    Drop = c.Int(nullable: false),
                    punt = c.Int(nullable: false),
                    grubber = c.Int(nullable: false),
                    Goal = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    playerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Players", t => t.playerId, cascadeDelete: true)
                .Index(t => t.playerId);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "TrainingRecord_id", c => c.Int());
            CreateIndex("dbo.Players", "TrainingRecord_id");
            AddForeignKey("dbo.Players", "TrainingRecord_id", "dbo.TrainingRecords", "id");
            DropForeignKey("dbo.Skills", "playerId", "dbo.Players");
            DropForeignKey("dbo.Guardians", "playerID", "dbo.Players");
            DropForeignKey("dbo.Players", "tr_id", "dbo.TrainingRecords");
            DropForeignKey("dbo.TrainingRecords", "nonPlayer_id", "dbo.nonPlayers");
            DropForeignKey("dbo.GameRecords", "coachID", "dbo.nonPlayers");
            DropIndex("dbo.Skills", new[] { "playerId" });
            DropIndex("dbo.TrainingRecords", new[] { "nonPlayer_id" });
            DropIndex("dbo.Players", new[] { "tr_id" });
            DropIndex("dbo.Guardians", new[] { "playerID" });
            DropIndex("dbo.GameRecords", new[] { "coachID" });
            DropTable("dbo.Skills");
            DropTable("dbo.TrainingRecords");
            DropTable("dbo.Players");
            DropTable("dbo.Guardians");
            DropTable("dbo.nonPlayers");
            DropTable("dbo.GameRecords");
        }
    }
}
