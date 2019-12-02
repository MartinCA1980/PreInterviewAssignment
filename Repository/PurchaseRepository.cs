using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PurchaseRepository: IPurchaseRepository
    {
        private readonly FCTSampleContext db;
        public PurchaseRepository(FCTSampleContext context)
        {
            db = context;
        }

        public void Add(Purchase purchase)
        {
            db.Purchase.Add(purchase);
        }

        public Purchase Get(int id)
        {
            return db.Purchase.Find(id);
        }

        public void Remove(Purchase purchase)
        {
            db.Purchase.Remove(purchase);
        }

        public void RemoveById(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            if (purchase != null)
            {
                db.Purchase.Remove(purchase);
            }
        }
    }
}
