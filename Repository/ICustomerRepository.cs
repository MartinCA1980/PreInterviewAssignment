using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        
        Customer GetByEmail(string email);
        
        void Add(Customer customer);
        
        void Remove(Customer customer);
        
        void RemoveById(int id);
    }
}
