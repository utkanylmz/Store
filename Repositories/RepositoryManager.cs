﻿using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public RepositoryManager(IProductRepository productRepository, RepositoryContext context, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}