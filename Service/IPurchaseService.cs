using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;

namespace Service
{
    public interface IPurchaseService
    {



        List<PurchaseListingModel> GetPurchasesForUser();

        PurchaseListingModel Get(int id);

        void Remove(int id);

        void PurchaseProductById(int id);
    }
}
