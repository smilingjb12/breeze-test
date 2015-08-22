using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Car
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}