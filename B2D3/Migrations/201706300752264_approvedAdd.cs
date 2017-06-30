namespace B2D3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approvedAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Approved");
        }
    }
}
