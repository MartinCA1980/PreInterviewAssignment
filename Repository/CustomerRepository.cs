using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly FCTSampleContext db;
        public CustomerRepository(FCTSampleContext context)
        {
            db = context;
        }

        public Customer GetById(int id)
        {
            return db.Customer.Find(id);
        }

        public Customer GetByEmail(string email)
        {
            return db.Customer.Where(f => f.Email == email).FirstOrDefault();
        }

        public void Add(Customer customer)
        {
            db.Customer.Add(customer);
        }

        public void Remove(Customer customer)
        {
            db.Customer.Remove(customer);
        }

        public void RemoveById(int id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer != null)
            {
                db.Customer.Remove(customer);
            }
        }

    }

}
