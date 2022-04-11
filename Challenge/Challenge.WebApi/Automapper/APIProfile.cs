using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Service = Challenge.Services.Models;
using Api = Challenge.WebApi.Models;

namespace Challenge.WebApi.Automapper
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Service to API
            CreateMap<Service.ProductResult, Api.ProductResponse>();
            CreateMap<Service.ProductDetailResult, Api.ProductDetailResponse>();
            CreateMap<Service.ExternalProductResult, Api.ExternalProductResponse>();
            CreateMap<Service.ProductTypeResult, Api.ProductTypeResponse>();

            // API to Service
            CreateMap<Api.ProductInsertRequest, Service.ProductInsertParams>();
            CreateMap<Api.ProductUpdateRequest, Service.ProductUpdateParams>();
        }
    }
}
