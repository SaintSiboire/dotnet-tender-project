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
            var activityBasketball = new Item() { Name = "Adjustable Voltage Regulator / Reducing Module" };
            var activityBiking = new Item() { Name = "Biking" };
            var activityHiking = new Item() { Name = "Hiking" };
            var activityKayaking = new Item() { Name = "Kayaking" };
            var activityPokemonGo = new Item() { Name = "Pokemon Go" };
            var activityRunning = new Item() { Name = "Running" };
            var activitySkiing = new Item() { Name = "Skiing" };
            var activitySwimming = new Item() { Name = "Swimming" };
            var activityWalking = new Item() { Name = "Walking" };
            var activityWeightLifting = new Item() { Name = "Weight Lifting" };

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

            var activities = new List<Item>()
            {
                activityBasketball,
                activityBiking,
                activityHiking,
                activityKayaking,
                activityPokemonGo,
                activityRunning,
                activitySkiing,
                activitySwimming,
                activityWalking,
                activityWeightLifting
            };

            context.Items.AddRange(activities);

            var entries = new List<Entry>()
            {
                new Entry(userBob, 2017, 7, 8, activityBasketball, 10.0m),
                new Entry(userBob, 2017, 7, 9, activityBiking, 12.2m),
                new Entry(userPet, 2017, 7, 10, activityHiking, 123.0m),
                new Entry(userBob, 2017, 7, 12, activityBiking, 10.0m),
                new Entry(userPet, 2017, 7, 13, activityWalking, 32.2m),
                new Entry(userPet, 2017, 7, 13, activityBiking, 13.3m),
                new Entry(userBob, 2017, 7, 14, activityBiking, 10.0m),
                new Entry(userPet, 2017, 7, 15, activityWalking, 28.6m),
                new Entry(userBob, 2017, 7, 16, activityBiking, 12.7m),
                new Entry(userPet, 2017, 7, 16, activityPokemonGo, 23.4m)
            };

            context.Entries.AddRange(entries);

            context.SaveChanges();
        }
    }
}
