using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands;
using ProductApp.Application.Wrappers;
using System.Threading.Tasks;

namespace ProductApp.WebApi.Operations.Abstract
{
    public interface IProductOperations
    {
        Task<ServiceResponse<ProductDto>> Post(CreateProductCommand command);
        Task<IActionResult> Get()
    }
}
