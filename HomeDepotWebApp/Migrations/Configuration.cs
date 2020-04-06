namespace HomeDepotWebApp.Migrations
{
    using HomeDepotWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeDepotWebApp.Storage.HomeDepotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeDepotWebApp.Storage.HomeDepotContext context)
        {
            context.Tools.AddOrUpdate(t => t.Name, new Tool {Name= "TestItem", Description="Test item info", DailyRent=100, Deposit = 10});
            context.Customers.AddOrUpdate(c => c.Name, new Customer {Name = "TestCustomer", Address = "TestAddress", Email= "TestEmail",Username = "TestUser",Password = "Test"});
            context.Customers.AddOrUpdate(c => c.Name, new Customer { Name = "TestCustomer2", Address = "TestAddress2", Email = "TestEmail2", Username = "TestUser2", Password = "Test" });
            context.Bookings.AddOrUpdate(b => b.Id, new Booking { PickUpDate = DateTime.Today, Status = "Booked" ,Days=1, CustomerID=1,ToolID=1});
        }
    }
}
