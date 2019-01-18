namespace DiceGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishedGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player1Id = c.Int(nullable: false),
                        Player2Id = c.Int(nullable: false),
                        Current1 = c.Int(nullable: false),
                        Current2 = c.Int(nullable: false),
                        Score1 = c.Int(nullable: false),
                        Score2 = c.Int(nullable: false),
                        Turn = c.Int(nullable: false),
                        DesignedGameId = c.Int(nullable: false),
                        finished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommenterId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Comment = c.String(),
                        date = c.String(),
                        flag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GameComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommenterId = c.Int(nullable: false),
                        ThingId = c.Int(nullable: false),
                        Comment = c.String(),
                        date = c.String(),
                        flag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OnlineGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player1Id = c.Int(nullable: false),
                        Player2Id = c.Int(nullable: false),
                        Current1 = c.Int(nullable: false),
                        Current2 = c.Int(nullable: false),
                        Score1 = c.Int(nullable: false),
                        Score2 = c.Int(nullable: false),
                        Turn = c.Int(nullable: false),
                        DesignedGameId = c.Int(nullable: false),
                        finished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Users", "BirthDay", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "UserId", "dbo.Users");
            DropIndex("dbo.UserComments", new[] { "UserId" });
            AlterColumn("dbo.Users", "BirthDay", c => c.DateTime(nullable: false));
            DropTable("dbo.OnlineGames");
            DropTable("dbo.GameComments");
            DropTable("dbo.UserComments");
            DropTable("dbo.FinishedGames");
        }
    }
}
