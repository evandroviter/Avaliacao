using FluentValidation;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Icatu.Service.Services
{
    public abstract class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T Get(int id)
        {
            return _repository.Get(id);
        }

        public virtual T Post<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());
            _repository.Insert(entity);
            return entity;
        }

        public virtual T Put<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());
            _repository.Update(entity);
            return entity;
        }

        protected void Validate(T entity, AbstractValidator<T> validator)
        {
            if (entity == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(entity);
        }
    }
}
