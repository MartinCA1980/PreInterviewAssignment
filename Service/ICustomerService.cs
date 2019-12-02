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
    public interface ICustomerService
    {




        CustomerModel SignIn(string email, string password);

        List<Model.PurchaseListingModel> GetPurchasesForUser();

        CustomerModel Add(CustomerModel customer);
    }
}
