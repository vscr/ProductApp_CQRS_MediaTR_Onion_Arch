using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands;
using ProductApp.Application.Features.Queries;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductDto>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _repository.GetAllAsync();
            var dtoList = mapper.Map<List<ProductDto>>(products);
            return new ServiceResponse<List<ProductDto>>(dtoList);
        }
    }
}
