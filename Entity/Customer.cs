using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Customer
    {
        public Customer()
        {
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
