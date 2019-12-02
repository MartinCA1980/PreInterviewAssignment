using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Product
    {
        public Product()
        {
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
