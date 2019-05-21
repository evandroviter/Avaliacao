using FluentValidation;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using Icatu.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Icatu.Test.Domain
{
    public class EnderecoServiceFake : IEnderecoService
    {
        private readonly List<Endereco> _enderecos;

        public EnderecoServiceFake()
        {
            _enderecos = new List<Endereco>
            {
                new Endereco{Id = 1, ClienteId = 1, Logradouro = "Rua A, 30", Bairro = "Novo Bairro A", Cidade = "Cidade Nova A", Estado = "Rio de Janeiro"},
                new Endereco{Id = 2, ClienteId = 2, Logradouro = "Rua B, 30", Bairro = "Novo Bairro B", Cidade = "Cidade Nova B", Estado = "Rio de Janeiro"},
                new Endereco{Id = 3, ClienteId = 3, Logradouro = "Rua C, 30", Bairro = "Novo Bairro C", Cidade = "Cidade Nova C", Estado = "Rio de Janeiro"}
            };
        }
        public void Delete(int id)
        {
            var existing = _enderecos.First(x => x.Id == id);
            _enderecos.Remove(existing);
        }

        public Endereco Get(int id)
        {
            return _enderecos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _enderecos;
        }

        public Endereco Post<V>(Endereco entity) where V : AbstractValidator<Endereco>
        {
            var validator = new EnderecoValidator().Validate(entity);
            if (!validator.IsValid)
                throw new Exception();

            _enderecos.Add(entity);
            return entity;
        }

        public Endereco Put<V>(Endereco entity) where V : AbstractValidator<Endereco>
        {
            var existing = _enderecos.First(x => x.Id == entity.Id);
            _enderecos.Remove(existing);

            existing.Id = entity.Id;
            existing.ClienteId = entity.ClienteId;
            existing.Logradouro = entity.Logradouro;
            existing.Bairro = entity.Bairro;
            existing.Cidade = entity.Cidade;
            existing.Estado = entity.Estado;

            var validator = new EnderecoValidator().Validate(entity);
            if (!validator.IsValid)
                throw new Exception();
            _enderecos.Add(existing);

            return entity;
        }
    }
}
