using Challenge.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Interfaces
{
    public interface IProductService
    {
        ProductResult GetProductById(int productId);
        ProductResult InsertProduct(ProductInsertParams productParams);
        ProductResult UpdateProduct(ProductUpdateParams productParams);
    }
}
