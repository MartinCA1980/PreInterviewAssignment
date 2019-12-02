using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;
using Repository;
using Entity;

namespace Service
{
    public class ProductService : IProductService
    {

        private readonly FCTSampleContext db;
        private readonly IProductRepository _productRepository;
        public ProductService(FCTSampleContext context,
                                IProductRepository productRepository)
        {
            db = context;
            _productRepository = productRepository;
        }

        public List<ProductListingModel> GetAll()
        {
            List<Product> products = _productRepository.GetAll();
            return products.Select(p => new ProductListingModel()
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public ProductListingModel Get(int id)
        {
            Product product = _productRepository.Get(id);
            if (product == null) { return null; }

            return new ProductListingModel()
            {
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
