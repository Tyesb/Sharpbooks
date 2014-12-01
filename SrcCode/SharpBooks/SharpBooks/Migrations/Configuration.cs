namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SharpBooks.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpBooks.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SharpBooks.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Books.AddOrUpdate(
              p => p.Title,
              new Book { Title = "Andrew Peters Screams", Author=Faker.NameFaker.Name() },
              new Book { Title = "Brice Lambson & the Bunny Rabbit", Author = Faker.NameFaker.Name() },
              new Book { Title = "The Life & Struggles of Rowan Miller", Author = Faker.NameFaker.Name() }
            );
            
        }
    }
}
