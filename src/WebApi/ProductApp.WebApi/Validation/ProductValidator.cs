using FluentValidation;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands;

namespace ProductApp.WebApi.Validation
{
    public class ProductValidator: AbstractValidator<CreateProductCommand>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull().NotEmpty();
            RuleFor(product => product.Value).NotNull().NotEqual(0);
            RuleFor(product => product.Quantity).NotNull().NotEqual(0);
        }
    }
}
