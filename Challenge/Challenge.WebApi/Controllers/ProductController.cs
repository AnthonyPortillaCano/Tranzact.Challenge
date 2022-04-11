using AutoMapper;
using Challenge.Services.Interfaces;
using Challenge.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service = Challenge.Services.Models;
namespace Challenge.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IMapper mapper,
           IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public ActionResult GetById(int productId)
        {
            var result = _productService.GetProductById(productId);

            return Ok(_mapper.Map<ProductResponse>(result));
        }
        [HttpPost]
        public ActionResult Insert([FromBody] ProductInsertRequest request)
        {
            var productParams = _mapper.Map<Service.ProductInsertParams>(request);

            var result = _productService.InsertProduct(productParams);

            return Ok(_mapper.Map<ProductResponse>(result));
        }

        [HttpPut]
        public ActionResult Update([FromBody] ProductUpdateRequest request)
        {
            var productParams = _mapper.Map<Service.ProductUpdateParams>(request);

            var result = _productService.UpdateProduct(productParams);

            return Ok(_mapper.Map<ProductResponse>(result));
        }
    }
}
