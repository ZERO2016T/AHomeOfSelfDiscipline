namespace AHomeOfSelfDiscipline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabaseSecond : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PulisherId = c.Int(),
                        PulisherName = c.Int(nullable: false),
                        MatchSubject = c.String(),
                        MatchContent = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        PublcationCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PulisherId = c.Int(nullable: false),
                        PulisherName = c.Int(nullable: false),
                        NoticeSubject = c.String(),
                        NoticeContent = c.String(),
                        PublishTime = c.String(),
                        PublcationCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notices");
            DropTable("dbo.Matches");
        }
    }
}
