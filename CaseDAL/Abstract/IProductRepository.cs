﻿using CaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> FilterProducts(string sortOrder, string category);
    }
    
}
