using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Models
{
    public class ProductResult
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public int ProductTypeId { get; set; }

        public ProductDetailResult ProductDetail { get; set; }
        public ExternalProductResult ExternalProduct { get; set; }
        public ProductTypeResult ProductType { get; set; }
    }
}
