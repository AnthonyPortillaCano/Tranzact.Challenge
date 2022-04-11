using Challenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
        Product InsertProduct(Product product);
        Product UpdateProduct(Product product);
    }
}
