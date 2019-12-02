using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FCTSampleContext db;
        public ProductRepository(FCTSampleContext context)
        {
            db = context;
        }

        public List<Product> GetAll()
        {
            return db.Product.ToList();
        }

        public Product Get(int id)
        {
            return db.Product.Find(id);
        }
    }
}
