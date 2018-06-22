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

            var part1 = new Part() { Name = "Adjustable Voltage Regulator / Reducing Module" };
            var part2 = new Part() { Name = "Biking" };
            var part3 = new Part() { Name = "Hiking" };
            var part4 = new Part() { Name = "Kayaking" };
            var part5 = new Part() { Name = "Pokemon Go" };
            var part6 = new Part() { Name = "Running" };
            var part7 = new Part() { Name = "Skiing" };
            var part8 = new Part() { Name = "Swimming" };
            var part9 = new Part() { Name = "Walking" };
            var part10 = new Part() { Name = "Weight Lifting" };

            var parts = new List<Part>()
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

            var shop1 = new Shop() { Name = "Shop1", WebSite = "shop1@gmail.com" };
            var shop2 = new Shop() { Name = "Shop2", WebSite = "shop2@gmail.com" };

            var shops = new List<Shop>()
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


            var inventory1 = new Inventory() { Part = part1, Project = project1, Shop = shop1, Price = 10m };
            context.Inventories.Add(inventory1);

            var inventory2 = new Inventory() { Part = part2, Project = project2, Shop = shop2, Price = 13m };
            context.Inventories.Add(inventory2);

            context.SaveChanges();
        }
    }
}
