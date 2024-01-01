namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AuthorName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Blogby = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Catagory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Blogby)
                .Index(t => t.Blogby);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        CommentedBy = c.String(maxLength: 128),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CommentedBy)
                .Index(t => t.CommentedBy)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        Profession = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        ProductRating = c.Int(nullable: false),
                        ReviewedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReviewedBy)
                .Index(t => t.ReviewedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "ReviewedBy", "dbo.Users");
            DropForeignKey("dbo.Blogs", "Blogby", "dbo.Users");
            DropForeignKey("dbo.Comments", "CommentedBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.ProductReviews", new[] { "ReviewedBy" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Comments", new[] { "CommentedBy" });
            DropIndex("dbo.Blogs", new[] { "Blogby" });
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
        }
    }
}
