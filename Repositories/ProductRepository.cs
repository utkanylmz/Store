﻿using Entities.Models;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(RepositoryContext context):base(context)
        {
            
        }
        public IQueryable<Product> GetAllProducts(bool trackChanges)=>FindAll(trackChanges);

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p=>p.Id.Equals(id),trackChanges);
        }
    }
}
