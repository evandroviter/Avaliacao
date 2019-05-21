using FluentValidation;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using Icatu.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Icatu.Test.Domain
{
    public class ClienteServiceFake : IClienteService
    {
        private readonly List<Cliente> _clientes;
        public ClienteServiceFake()
        {
            _clientes = new List<Cliente>
            {
                new Cliente{ Id = 1, Nome = "Evandro Viter", Cpf = "12345678910", Idade = 44 },
                new Cliente{ Id = 2, Nome = "João da Silva", Cpf = "14785236978", Idade = 30 },
                new Cliente{ Id = 3, Nome = "Maria da Silva", Cpf = "36985214785", Idade = 52 }
            };
        }
        public void Delete(int id)
        {
            var existing = _clientes.First(x => x.Id == id);
            _clientes.Remove(existing);
        }

        public Cliente Get(int id)
        {
            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clientes;
        }

        public Cliente Post<V>(Cliente entity) where V : AbstractValidator<Cliente>
        {
            var validator = new ClienteValidator().Validate(entity);
            if (!validator.IsValid)
                throw new Exception();

            _clientes.Add(entity);
            return entity;
        }

        public Cliente Put<V>(Cliente entity) where V : AbstractValidator<Cliente>
        {
            var existing = _clientes.First(x => x.Id == entity.Id);
            _clientes.Remove(existing);

            existing.Id = entity.Id;
            existing.Nome = entity.Nome;
            existing.Cpf = entity.Cpf;
            existing.Idade = entity.Idade;

            var validator = new ClienteValidator().Validate(entity);
            if (!validator.IsValid)
                throw new Exception();

            _clientes.Add(existing);

            return entity;
        }
    }
}
