using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Repository;
using Entity;

namespace Service
{
    public class PurchaseService : IPurchaseService
    {

        private readonly FCTSampleContext db;
        private readonly IHttpContextAccessor _ctxAccessor;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;

        public PurchaseService(FCTSampleContext context,
                               IHttpContextAccessor httpContextAccessor,
                               IPurchaseRepository purchaseRepository,
                               IProductRepository productRepository)
        {
            db = context;
            _ctxAccessor = httpContextAccessor;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }

        public void PurchaseProductById(int id)
        {
            var userId = Convert.ToInt32(_ctxAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Product productEntity = _productRepository.Get(id);
            if (productEntity == null) { throw new Exception("Invalid Product"); }
            Purchase purchaseEntity = new Purchase()
            {
                Price = productEntity.Price,
                ProductId = productEntity.Id,
                UserId = userId
            };
            _purchaseRepository.Add(purchaseEntity);
            db.SaveChanges();
        }

        public PurchaseListingModel Get(int id)
        {
            return (from purchase in db.Purchase
                    join product in db.Product on purchase.ProductId equals product.Id
                    join customer in db.Customer on purchase.UserId equals customer.Id
                    where purchase.Id == id
                    select new PurchaseListingModel()
                    {
                        Id = purchase.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    }).FirstOrDefault();
        }
        public void Remove(int id)
        {
            _purchaseRepository.RemoveById(id);
            db.SaveChanges();
        }
        public List<Model.PurchaseListingModel> GetPurchasesForUser()
        {
            var userId = Convert.ToInt32(_ctxAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var username = _ctxAccessor.HttpContext.User.Identity.Name;

            return (from purchase in db.Purchase
                    join product in db.Product on purchase.ProductId equals product.Id
                    join customer in db.Customer on purchase.UserId equals customer.Id
                    where purchase.UserId == userId
                    select new PurchaseListingModel()
                    {
                        Id = purchase.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    }).ToList();
        }
    }
}
