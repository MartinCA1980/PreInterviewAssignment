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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly FCTSampleContext db;

        public CustomerService(FCTSampleContext context, ICustomerRepository customerRepository)
        {
            db = context;
            _customerRepository = customerRepository;
        }

        public CustomerModel SignIn(string email, string password)
        {
            Customer customer = _customerRepository.GetByEmail(email);
            if (customer == null) { return null; }
            if (customer.Password != password) { return null; }
            return new CustomerModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };
        }

        public CustomerModel Add(CustomerModel customer)
        {
            Customer customerEntity = _customerRepository.GetByEmail(customer.Email);
            if(customerEntity!= null) { throw new Exception("User Already Exists"); }
            customerEntity = new Customer()
            {
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password,
            };
            _customerRepository.Add(customerEntity);
            db.SaveChanges();
            customer.Id = customerEntity.Id;
            return customer;
        }
        public List<Model.PurchaseListingModel> GetPurchasesForUser()
        {
            return (from purchase in db.Purchase
                    join product in db.Product on purchase.ProductId equals product.Id
                    join customer in db.Customer on purchase.UserId equals customer.Id
                    where purchase.UserId == 1
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
