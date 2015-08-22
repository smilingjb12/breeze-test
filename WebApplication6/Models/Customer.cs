using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual Company Company { get; set; }
        public long CompanyId { get; set; }
        public virtual ICollection<Car> Cars { get; set; } 
    }
}