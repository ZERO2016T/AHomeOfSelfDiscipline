namespace AHomeOfSelfDiscipline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentNumber = c.String(nullable: false, maxLength: 11),
                        NickName = c.String(),
                        Name = c.String(nullable: false, maxLength: 11),
                        Password = c.String(),
                        Photo = c.String(nullable: false),
                        Sex = c.String(),
                        ThemColor = c.String(),
                        DateOfBirth = c.DateTime(),
                        ContactPhoneNumber = c.String(),
                        QQ = c.String(),
                        MailAddress = c.String(),
                        Motto = c.String(),
                        Grade = c.String(),
                        Major = c.String(),
                        Address = c.String(),
                        Post = c.String(),
                        Authority = c.String(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
