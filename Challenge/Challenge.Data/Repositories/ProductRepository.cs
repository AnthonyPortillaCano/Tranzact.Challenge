using Challenge.Data.Context;
using Challenge.Data.Interfaces;
using Challenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDatabaseContext _storeDatabaseContext;

        public ProductRepository(StoreDatabaseContext storeDatabaseContext)
        {
            _storeDatabaseContext = storeDatabaseContext;
        }

        public Product GetProductById(int productId)
        {
            return _storeDatabaseContext.Product.Where(o => o.ProductId == productId).Include(o=> o.ProductDetail).FirstOrDefault();
        }

        public Product InsertProduct(Product product)
        {
            _storeDatabaseContext.Product.Add(product);
            _storeDatabaseContext.SaveChanges();

            return GetProductById(product.ProductId);
        }

        public Product UpdateProduct(Product product)
        {
            _storeDatabaseContext.Product.Update(product);
            _storeDatabaseContext.SaveChanges();

            return GetProductById(product.ProductId);
        }
    }
}
