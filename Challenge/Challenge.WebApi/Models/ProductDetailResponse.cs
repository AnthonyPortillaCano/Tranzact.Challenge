using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.WebApi.Models
{
    public class ProductDetailResponse
    {
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Observations { get; set; }
    }
}
