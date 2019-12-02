using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IPurchaseRepository
    {
        void Add(Purchase purchase);


        void Remove(Purchase purchase);

        void RemoveById(int id);

        Purchase Get(int id);
    }
}
