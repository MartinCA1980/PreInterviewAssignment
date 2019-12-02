using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;

namespace Service
{
    public interface IProductService
    {



        List<Model.ProductListingModel> GetAll();

        Model.ProductListingModel Get(int id);
        
    }
}
