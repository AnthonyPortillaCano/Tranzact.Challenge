using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.MinimalApi.Models
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public int ProductTypeId { get; set; }

        public ProductDetailResponse ProductDetail { get; set; }
        public ExternalProductResponse ExternalProduct { get; set; }
        public ProductTypeResponse ProductType { get; set; }
    }
}
