﻿using ProductApp.Domain.Common;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T>AddAsync(T entity);
    }
}
