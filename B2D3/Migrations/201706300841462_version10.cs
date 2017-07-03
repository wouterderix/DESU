namespace B2D3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Histories", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Occasions", "IsApproved");
            DropColumn("dbo.Products", "IsApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Occasions", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Histories", "IsApproved");
        }
    }
}
