using AutoMapper;
using Challenge.Data.Interfaces;
using Challenge.External.Interfaces;
using Challenge.External.Models;
using Challenge.Services.Interfaces;
using Challenge.Services.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

using DA = Challenge.Data.Models;

namespace Challenge.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IExternalProxy _externalProxy;

        public ProductService(IMapper mapper, 
            IProductRepository productRepository,
            IExternalProxy externalProxy)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _externalProxy = externalProxy;
        }

        public ProductResult GetProductById(int productId)
        {
            ProductResult productResult = null;

            var response = _productRepository.GetProductById(productId);
            productResult = _mapper.Map<ProductResult>(response);

            var externalProductResponse = _externalProxy.GetExternalProductById(productId);

            if (externalProductResponse != null && externalProductResponse.ProductId != 0)
            {
                productResult.ExternalProduct = _mapper.Map<ExternalProductResult>(externalProductResponse);
            }

            ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
            List<ProductType> productTypes = (List<ProductType>)cache["ProductTypes"];

            if (productTypes != null && productTypes.Count > 0)
            {
                var search = productTypes.Where(o => o.ProductTypeId == productResult.ProductTypeId).FirstOrDefault();

                if (search != null)
                {
                    productResult.ProductType = _mapper.Map<ProductTypeResult>(search);
                }
            }

            return productResult;
        }

        public ProductResult InsertProduct(ProductInsertParams productParams)
        {
            var product = _mapper.Map<DA.Product>(productParams);

            var response = _productRepository.InsertProduct(product);

            return _mapper.Map<ProductResult>(response);
        }

        public ProductResult UpdateProduct(ProductUpdateParams productParams)
        {
            var product = _mapper.Map<DA.Product>(productParams);

            var response = _productRepository.UpdateProduct(product);

            return _mapper.Map<ProductResult>(response);
        }
    }
}
