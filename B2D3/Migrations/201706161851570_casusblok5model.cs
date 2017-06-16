namespace B2D3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class casusblok5model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Description = c.String(unicode: false),
                        AccountLevel = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        OperationArea_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationAreas", t => t.OperationArea_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.OperationArea_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        EmailAddress = c.String(nullable: false, unicode: false),
                        Subject = c.String(nullable: false, unicode: false),
                        Message = c.String(nullable: false, unicode: false),
                        SubmittedUser_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.SubmittedUser_ID, cascadeDelete: true)
                .Index(t => t.SubmittedUser_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Password = c.Binary(nullable: false),
                        IsActivel = c.Boolean(nullable: false),
                        AccountRole_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccountRoles", t => t.AccountRole_ID, cascadeDelete: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.AccountRole_ID);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        LogDate = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Users", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(nullable: false, unicode: false),
                        ReviewDate = c.DateTime(nullable: false, precision: 0),
                        IsAnonymous = c.Boolean(nullable: false),
                        Author_ID = c.Int(nullable: false),
                        Product_ID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Author_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => new { t.Product_ID, t.Product_Version })
                .Index(t => t.Author_ID)
                .Index(t => new { t.Product_ID, t.Product_Version });
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Address = c.String(nullable: false, unicode: false),
                        ZipCode = c.String(nullable: false, unicode: false),
                        Phone = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.OperationAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(nullable: false, unicode: false),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.ID, t.Version })
                .Index(t => new { t.ID, t.Version })
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Location = c.String(nullable: false, unicode: false),
                        MoreInformationURL = c.String(nullable: false, unicode: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.ID, t.Version })
                .Index(t => new { t.ID, t.Version });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(),
                        Supplier_ID = c.Int(),
                        Name = c.String(maxLength: 100, storeType: "nvarchar"),
                        Quantity = c.Int(nullable: false),
                        Information = c.String(unicode: false),
                        ExpirationDate = c.DateTime(nullable: false, precision: 0),
                        TimesViewed = c.Int(nullable: false),
                        IsCompensated = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.ID, t.Version })
                .ForeignKey("dbo.Categories", t => t.ProductCategory_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => new { t.ID, t.Version })
                .Index(t => t.ProductCategory_Id)
                .Index(t => t.Supplier_ID)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", new[] { "ID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.Occasions", new[] { "ID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.News", new[] { "ID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.Categories", "OperationArea_Id", "dbo.OperationAreas");
            DropForeignKey("dbo.Contacts", "SubmittedUser_ID", "dbo.Users");
            DropForeignKey("dbo.ProductReviews", new[] { "Product_ID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.ProductReviews", "Author_ID", "dbo.Users");
            DropForeignKey("dbo.Histories", "ID", "dbo.Users");
            DropForeignKey("dbo.Users", "AccountRole_ID", "dbo.AccountRoles");
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "Supplier_ID" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Products", new[] { "ID", "Version" });
            DropIndex("dbo.Occasions", new[] { "ID", "Version" });
            DropIndex("dbo.News", new[] { "Title" });
            DropIndex("dbo.News", new[] { "ID", "Version" });
            DropIndex("dbo.OperationAreas", new[] { "Name" });
            DropIndex("dbo.Suppliers", new[] { "Name" });
            DropIndex("dbo.ProductReviews", new[] { "Product_ID", "Product_Version" });
            DropIndex("dbo.ProductReviews", new[] { "Author_ID" });
            DropIndex("dbo.Histories", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "AccountRole_ID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Contacts", new[] { "SubmittedUser_ID" });
            DropIndex("dbo.Categories", new[] { "OperationArea_Id" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.AccountRoles", new[] { "Name" });
            DropTable("dbo.Products");
            DropTable("dbo.Occasions");
            DropTable("dbo.News");
            DropTable("dbo.OperationAreas");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Histories");
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountRoles");
        }
    }
}
