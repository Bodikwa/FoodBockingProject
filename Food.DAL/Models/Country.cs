using System;
using System.Collections.Generic;

#nullable disable

namespace Food.DAL.Models
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
