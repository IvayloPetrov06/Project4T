﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Project4T.Core.IServices;
using Project4T.Core.Validators;
using Project4T.DataAccess.Repository;
using Project4T.Models;

namespace Project4T.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repo;

        public ProductService(IRepository<Product> repo)
        {
            this._repo = repo;
        }
        private bool ValidateProduct(Product Product)
        {
            if (!ProductValidator.ValidateInput(Product.Name, Product.Price))
            {
                return false;
            }
            else if (!CategoryValidator.CategoryExist(Product.CategoryId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Add(Product product)
        {
            if (!ValidateProduct(product))
            {
                throw new ArgumentException("The product is not valid!");
            }
            _repo.Add(product);

        }

        public Product GetById(int id)
        {
            return _repo.Get(id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            if (CategoryValidator.CategoryExist(categoryId))
            {
                return _repo.Find(x=>x.CategoryId==categoryId);
            }
            else
            {
                throw new ArgumentException("The category is not valid!");
            }
        }

        public void Update(Product product)
        {
            if (!ValidateProduct(product))
            {
                throw new ArgumentException("The product is not valid!");
            }
            _repo.Update(product);
        }

        public void Delete(int id)
        {
            if (ProductValidator.ProductExists(id))
            {
                _repo.Delete(id);
            }
            
        }

        public List<Product> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Product> Find(Expression<Func<Product, bool>> filter)
        {
            return _repo.Find(filter);
        }
    }
}
