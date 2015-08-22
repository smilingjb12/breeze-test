using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin;
using Owin;
using WebApplication6.Models;

[assembly: OwinStartup(typeof(WebApplication6.Startup))]

namespace WebApplication6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
            using (var db = new AppDbContext())
            {
                db.Companies.Add(new Company
                {
                    Title = "Company1",
                    Size = "Small",
                    Customers = new List<Customer>
                    {
                        new Customer()
                        {
                            Name = "Company1.Customer1",
                            Age = 42,
                            Cars = new List<Car>()
                            {
                                new Car()
                                {
                                    Make = "Audi",
                                    Year = 2013
                                },
                                new Car()
                                {
                                    Make = "BMW",
                                    Year = 2003
                                }
                            }
                        },
                        new Customer()
                        {
                            Name = "Company1.Customer2",
                            Age = 15
                        },
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
