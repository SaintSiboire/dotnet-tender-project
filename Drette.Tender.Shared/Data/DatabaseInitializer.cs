using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drette.Tender.Shared.Models;
using Drette.Tender.Shared.Security;

namespace Drette.Tender.Shared.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : CreateDatabaseIfNotExists<Context>
    {

        protected override void Seed(Context context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new ApplicationUserManager(userStore);

            var userBob = new User
            {
                UserName = "Bob@gmail.com",
                Email = "Bob@gmail.com"
            };

            userManager.Create(userBob, "qwerty");

            var userPet = new User
            {
                UserName = "pet@gmail.com",
                Email = "pet@gmail.com"
            };

            userManager.Create(userPet, "qwerty");

            var part1 = new Product() { Name = "Adjustable Voltage Regulator / Reducing Module" };
            var part2 = new Product() { Name = "Biking" };
            var part3 = new Product() { Name = "Hiking" };
            var part4 = new Product() { Name = "Kayaking" };
            var part5 = new Product() { Name = "Pokemon Go" };
            var part6 = new Product() { Name = "Running" };
            var part7 = new Product() { Name = "Skiing" };
            var part8 = new Product() { Name = "Swimming" };
            var part9 = new Product() { Name = "Walking" };
            var part10 = new Product() { Name = "Weight Lifting" };

            var parts = new List<Product>()
            {
                part1,
                part2,
                part3,
                part4,
                part5,
                part6,
                part7,
                part8,
                part9,
                part10
            };

            context.Parts.AddRange(parts);

            var shop1 = new Supplier() { Name = "Shop1", WebSite = "shop1@gmail.com" };
            var shop2 = new Supplier() { Name = "Shop2", WebSite = "shop2@gmail.com" };

            var shops = new List<Supplier>()
            {
                shop1,
                shop2
            };

            context.Shops.AddRange(shops);

            var project1 = new Project() { Name = "project1" };
            var project2 = new Project() { Name = "project2"};

            var projects = new List<Project>()
            {
                project1,
                project2
            };

            context.Projects.AddRange(projects);


            var inventory1 = new Inventory() { Product = part1, Supplier = shop1, Price = 10m };
            context.Inventories.Add(inventory1);

            var inventory2 = new Inventory() { Product = part2, Supplier = shop2, Price = 13m };
            context.Inventories.Add(inventory2);

            context.SaveChanges();
        }
    }
}
