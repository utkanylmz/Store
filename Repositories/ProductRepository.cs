using Entities.Models;
using Entities.RequestParameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contract;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context):base(context)
        {
            
        }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public void UpdateOneProduct(Product product) => Update(product);



        public IQueryable<Product> GetAllProducts(bool trackChanges)=>FindAll(trackChanges);

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public IQueryable<Product> GetAllProductsWithDeteils(ProductRequestParameters pro)
        {
            return context.Products.FilteredByCategoryId(pro.CategoryId)
                                    .FilteredBySearchTerm(pro.SearchTerm)
                                    .FilteredByPrice(pro.MinPrice,pro.MaxPrice,pro.IsValidPrice);
        }
    }
}
