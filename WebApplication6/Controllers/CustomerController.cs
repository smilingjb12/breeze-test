using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using WebApplication6.Models;
using System.Data.Entity;

namespace WebApplication6.Controllers
{
    [BreezeController]
    public class CustomerController : ApiController
    {
        private readonly EFContextProvider<AppDbContext> contextProvider = 
            new EFContextProvider<AppDbContext>();

        [HttpGet]
        public string Metadata()
        {
            return contextProvider.Metadata();
        }

        [HttpGet]
        public IQueryable<Company> Companies()
        {
            return contextProvider.Context.Companies;
        }

        [HttpGet]
        public IQueryable<Customer> Customers()
        {
            return contextProvider.Context.Customers;
        }

        [HttpGet]
        public IQueryable<Car> Cars()
        {
            return contextProvider.Context.Cars;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return contextProvider.SaveChanges(saveBundle);
        }
    }
}
