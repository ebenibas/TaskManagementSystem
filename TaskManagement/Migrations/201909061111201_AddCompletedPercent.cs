namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompletedPercent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CompletedPercent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CompletedPercent");
        }
    }
}
