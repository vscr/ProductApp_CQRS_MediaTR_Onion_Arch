using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Mapping;
using ProductApp.Application.Wrappers;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductDto>>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
