using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Interfaces.Repository
{
    public interface IProductRepository:IGenericRepositoryAsync<Product>
    {
    }
}
