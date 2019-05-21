using FluentValidation;
using Icatu.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Icatu.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);   
        T Post<V>(T entity) where V : AbstractValidator<T>;
        T Put<V>(T entity) where V : AbstractValidator<T>;
        void Delete(int id);
    }
}
