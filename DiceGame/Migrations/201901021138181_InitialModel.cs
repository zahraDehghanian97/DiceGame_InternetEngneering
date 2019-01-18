namespace DiceGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Email = c.String(),
                        WinNum = c.Int(),
                        RateTotal = c.Int(),
                        RateNum = c.Int(),
                        RateMean = c.Double(),
                        Picture = c.Binary(),
                        Online = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
