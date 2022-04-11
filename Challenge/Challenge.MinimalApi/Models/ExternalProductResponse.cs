using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.MinimalApi.Models
{
    public class ExternalProductResponse
    {
        public int ProductId { get; set; }
        public string RSA { get; set; }
        public decimal IGV { get; set; }
    }
}
