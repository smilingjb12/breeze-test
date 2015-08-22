using System.Collections;
using System.Collections.Generic;

namespace WebApplication6.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; } 
        public virtual ICollection<Customer> Customers { get; set; }
    }
}