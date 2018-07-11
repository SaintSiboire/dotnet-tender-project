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
                UserName = "Jim@gmail.com",
                Email = "Jim@gmail.com"
            };

            userManager.Create(userPet, "qwerty");

            var supplier1 = new Supplier() { Name = "Shop1", WebSite = "shop1@gmail.com" };
            var supplier2 = new Supplier() { Name = "Shop2", WebSite = "shop2@gmail.com" };

            var suppliers = new List<Supplier>()
            {
                supplier1,
                supplier2
            };

            context.Suppliers.AddRange(suppliers);

            var unit1 = new Unit() { Name = "Unité" };
            context.Units.Add(unit1);

            var inventory1 = new Inventory()
            {
                User = userBob,
                Counted = true,
                Followed = true,
                Location = "Box #1",
                LocationPrecision = "Storage #1",
                Notes = "My notes.",
                Unit = unit1,
                UnitQty = 0,
                UnitMinQty = 10,
                UnitMaxQty = 50,
                UnitQtyByLot = 1,
                OrderMinQty = 1
            };
            context.Inventories.Add(inventory1);

            var inventory2 = new Inventory()
            {
                User = userBob,
                Counted = true,
                Followed = true,
                Location = "Box #2",
                LocationPrecision = "Storage #1",
                Notes = "My notes.",
                Unit = unit1,
                UnitQty = 0,
                UnitMinQty = 13,
                UnitMaxQty = 55,
                UnitQtyByLot = 1,
                OrderMinQty = 1
            };
            context.Inventories.Add(inventory2);

            var productType1 = new ProductType() { Name = "Electronic" };
            context.ProductTypes.Add(productType1);

            var product1 = new Product()
            {
                User = userBob,
                Name = "Adjustable Voltage Regulator / Reducing Module",
                ProductCode = "3",
                Description = "My description.",
                ProductType = productType1,
                Inventory = inventory1,
                Supplier = supplier1,
                SupplierProductCode = "21",
                Date = DateTime.Now
            };
            var product2 = new Product()
            {
                User = userBob,
                Name = "Relay Module",
                ProductCode = "34",
                Description = "My description.",
                ProductType = productType1,
                Inventory = inventory2,
                Supplier = supplier2,
                SupplierProductCode = "5",
                Date = DateTime.Now
            };


            var products = new List<Product>()
            {
                product1,
                product2
            };

            context.Products.AddRange(products);

           

           


            context.SaveChanges();
        }
    }
}
