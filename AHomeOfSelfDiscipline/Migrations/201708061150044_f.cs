namespace AHomeOfSelfDiscipline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecondPost", c => c.String());
            AddColumn("dbo.Users", "GroupPost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "GroupPost");
            DropColumn("dbo.Users", "SecondPost");
        }
    }
}
