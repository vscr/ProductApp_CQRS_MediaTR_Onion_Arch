using AutoMapper;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands;
using ProductApp.Application.Features.Queries;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,GetAllProductsQuery>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

        }
    }
}
