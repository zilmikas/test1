
using System.Collections.Generic;

namespace CodeFirstDomain
{
    public class Customer :EntityBase
    {
        public string Name { get; set; }
        public Address ContactAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
