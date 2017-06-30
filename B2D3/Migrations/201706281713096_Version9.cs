namespace B2D3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version9 : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        EmailAddress = c.String(nullable: false, unicode: false),
                        Subject = c.String(nullable: false, unicode: false),
                        Message = c.String(nullable: false, unicode: false),
                        SubmittedUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.SubmittedUser_ID)
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
                "dbo.WorkItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, unicode: false),
                        Result = c.String(unicode: false),
                        IsReviewed = c.Boolean(nullable: false),
                        Product_HistoryID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version })
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, unicode: false),
                        Product_HistoryID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version })
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
            CreateTable(
                "dbo.Dimensions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        LogDate = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HistoryID, t.Version })
                .ForeignKey("dbo.Users", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureURL = c.String(nullable: false, unicode: false),
                        Product_HistoryID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version })
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
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
                "dbo.ProductReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(nullable: false, unicode: false),
                        StarRating = c.Int(nullable: false),
                        ReviewDate = c.DateTime(nullable: false, precision: 0),
                        IsAnonymous = c.Boolean(nullable: false),
                        Author_ID = c.Int(nullable: false),
                        Product_HistoryID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Author_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version })
                .Index(t => t.Author_ID)
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, unicode: false),
                        Product_HistoryID = c.Int(),
                        Product_Version = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version })
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
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
                "dbo.WorkItemUsers",
                c => new
                    {
                        WorkItem_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkItem_ID, t.User_ID })
                .ForeignKey("dbo.WorkItems", t => t.WorkItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.WorkItem_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.OperationAreaProducts",
                c => new
                    {
                        OperationArea_Id = c.Int(nullable: false),
                        Product_HistoryID = c.Int(nullable: false),
                        Product_Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OperationArea_Id, t.Product_HistoryID, t.Product_Version })
                .ForeignKey("dbo.OperationAreas", t => t.OperationArea_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => new { t.Product_HistoryID, t.Product_Version }, cascadeDelete: true)
                .Index(t => t.OperationArea_Id)
                .Index(t => new { t.Product_HistoryID, t.Product_Version });
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        HistoryID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(nullable: false, unicode: false),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.HistoryID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.HistoryID, t.Version })
                .Index(t => new { t.HistoryID, t.Version })
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        HistoryID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Location = c.String(nullable: false, unicode: false),
                        MoreInformationURL = c.String(nullable: false, unicode: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.HistoryID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.HistoryID, t.Version })
                .Index(t => new { t.HistoryID, t.Version });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        HistoryID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Dimension_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(),
                        Supplier_ID = c.Int(),
                        Name = c.String(nullable: false, unicode: false),
                        Information = c.String(unicode: false),
                        ExpirationDate = c.DateTime(nullable: false, precision: 0),
                        TimesViewed = c.Int(nullable: false),
                        IsCompensated = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsApproved = c.Boolean(nullable: false),
                        Weight = c.Single(nullable: false),
                        VideoURL = c.String(unicode: false),
                        UserGuideURL = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.HistoryID, t.Version })
                .ForeignKey("dbo.Histories", t => new { t.HistoryID, t.Version })
                .ForeignKey("dbo.Dimensions", t => t.Dimension_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.ProductCategory_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => new { t.HistoryID, t.Version })
                .Index(t => t.Dimension_Id)
                .Index(t => t.ProductCategory_Id)
                .Index(t => t.Supplier_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Dimension_Id", "dbo.Dimensions");
            DropForeignKey("dbo.Products", new[] { "HistoryID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.Occasions", new[] { "HistoryID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.News", new[] { "HistoryID", "Version" }, "dbo.Histories");
            DropForeignKey("dbo.WorkItems", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.Specifications", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.ProductReviews", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.ProductReviews", "Author_ID", "dbo.Users");
            DropForeignKey("dbo.OperationAreaProducts", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.OperationAreaProducts", "OperationArea_Id", "dbo.OperationAreas");
            DropForeignKey("dbo.Pictures", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.Demands", new[] { "Product_HistoryID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.Histories", "Author_ID", "dbo.Users");
            DropForeignKey("dbo.Contacts", "SubmittedUser_ID", "dbo.Users");
            DropForeignKey("dbo.WorkItemUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.WorkItemUsers", "WorkItem_ID", "dbo.WorkItems");
            DropForeignKey("dbo.Users", "AccountRole_ID", "dbo.AccountRoles");
            DropIndex("dbo.Products", new[] { "Supplier_ID" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Products", new[] { "Dimension_Id" });
            DropIndex("dbo.Products", new[] { "HistoryID", "Version" });
            DropIndex("dbo.Occasions", new[] { "HistoryID", "Version" });
            DropIndex("dbo.News", new[] { "Title" });
            DropIndex("dbo.News", new[] { "HistoryID", "Version" });
            DropIndex("dbo.OperationAreaProducts", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.OperationAreaProducts", new[] { "OperationArea_Id" });
            DropIndex("dbo.WorkItemUsers", new[] { "User_ID" });
            DropIndex("dbo.WorkItemUsers", new[] { "WorkItem_ID" });
            DropIndex("dbo.Suppliers", new[] { "Name" });
            DropIndex("dbo.Specifications", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.ProductReviews", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.ProductReviews", new[] { "Author_ID" });
            DropIndex("dbo.OperationAreas", new[] { "Name" });
            DropIndex("dbo.Pictures", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.Histories", new[] { "Author_ID" });
            DropIndex("dbo.Demands", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.WorkItems", new[] { "Product_HistoryID", "Product_Version" });
            DropIndex("dbo.Users", new[] { "AccountRole_ID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Contacts", new[] { "SubmittedUser_ID" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.AccountRoles", new[] { "Name" });
            DropTable("dbo.Products");
            DropTable("dbo.Occasions");
            DropTable("dbo.News");
            DropTable("dbo.OperationAreaProducts");
            DropTable("dbo.WorkItemUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Specifications");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.OperationAreas");
            DropTable("dbo.Pictures");
            DropTable("dbo.Histories");
            DropTable("dbo.Dimensions");
            DropTable("dbo.Demands");
            DropTable("dbo.WorkItems");
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountRoles");
        }
    }
}
