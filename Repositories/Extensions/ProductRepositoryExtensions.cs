﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,int? categoryId)
        {
            if (categoryId == 0)
                return products;
            else
            {
                return products.Where(prd => prd.CategoryId.Equals(categoryId));
            }
            
        } 

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return products;
            }
            else
            {
              return products.Where(prd => prd.ProductName.ToLower().Contains(searchTerm.ToLower()));
            }
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,decimal minPrice
            ,decimal maxPrice , bool isValidPrice)
        {
            if (isValidPrice)
            {
                return products.Where(prd => prd.Price >= minPrice && prd.Price <= maxPrice);
            }
            else
            {
                return products;
            }
               
        }
    }
}
