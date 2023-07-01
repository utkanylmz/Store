using Entities.Models;
using Entities.RequestParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDeteils(ProductRequestParameters pro);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product product);
    }
}
