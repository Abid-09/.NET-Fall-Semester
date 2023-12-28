namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TravelBlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.TravelBlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            Random random = new Random();
            for(int i = 1;  i <= 10; i++)
            {
                context.Users.AddOrUpdate(new Models.User
                {
                    Name = Guid.NewGuid().ToString().Substring(0,15),
                    UserName = "User-"+i,
                    Email = Guid.NewGuid().ToString().Substring(0,6)+"@gmail.com",
                    Contact = "01"+random.Next(111111111, 999999999),
                    Password = Guid.NewGuid().ToString().Substring(0,10),
                    Age = random.Next(17,65),
                    Gender = "Male",
                    Profession = Guid.NewGuid().ToString().Substring(0,7),
                    Type = "General"

                });
            }
            for (int i = 1;i <= 20;i++)
            {
                context.Blogs.AddOrUpdate(new Models.Blog
                {
                    Id = i,
                    AuthorName = Guid.NewGuid().ToString().Substring(1,15), 
                    Title = Guid.NewGuid().ToString().Substring(0,5),
                    Description = Guid.NewGuid().ToString(),
                    Type = "Normal",
                    Date = DateTime.Now,
                    Blogby = "User-" + random.Next(1,11)

                });
            }
            for(int i = 1; i <= 100;i++)
            {
                context.Comments.AddOrUpdate(new Models.Comment
                {
                    Id= i,
                    Description = Guid.NewGuid().ToString().Substring(1,5),
                    Time = DateTime.Now,
                    CommentedBy = "User-"+random.Next(1,11),
                    BlogId = random.Next(1,21),
                });
            }
            for(int i=1; i<=20; i++)
            {
                context.ProductReviews.AddOrUpdate(new Models.ProductReview
                {
                    Id =i,
                    ProductName = Guid.NewGuid().ToString().Substring(1,10),
                    ProductDescription = Guid.NewGuid().ToString(),
                    ProductRating = random.Next(1,5),
                    ReviewedBy = "User-"+random.Next(1,11),

                });
            }
        }
    }
}
