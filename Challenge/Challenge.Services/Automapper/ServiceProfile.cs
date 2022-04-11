using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service = Challenge.Services.Models;
using DA = Challenge.Data.Models;
using EX = Challenge.External.Models;

namespace Challenge.Services.Automapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            //DA to Service

            CreateMap<DA.Product, Service.ProductResult>();
            CreateMap<DA.ProductDetail, Service.ProductDetailResult>();

            //Service to DA

            CreateMap<Service.ProductInsertParams, DA.Product>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.ProductTypeId))
                .ForPath(dest => dest.ProductDetail.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.ProductDetail.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForPath(dest => dest.ProductDetail.Observations, opt => opt.MapFrom(src => src.Observations));

            CreateMap<Service.ProductUpdateParams, DA.Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.ProductTypeId))
                .ForPath(dest => dest.ProductDetail.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForPath(dest => dest.ProductDetail.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.ProductDetail.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForPath(dest => dest.ProductDetail.Observations, opt => opt.MapFrom(src => src.Observations));

            //External to Service
            CreateMap<EX.ExternalProduct, Service.ExternalProductResult>();
            CreateMap<EX.ProductType, Service.ProductTypeResult>();
        }
    }
}
