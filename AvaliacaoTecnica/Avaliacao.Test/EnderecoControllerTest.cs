using Avaliacao.Application.Controllers;
using Avaliacao.Domain.Entities;
using Avaliacao.Domain.Interfaces;
using Avaliacao.Test.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Avaliacao.Test
{
    public class EnderecoControllerTest
    {
        private readonly IEnderecoService _service;
        private readonly EnderecoController _controller;

        public EnderecoControllerTest()
        {
            _service = new EnderecoServiceFake();
            _controller = new EnderecoController(_service);
        }


        [Fact]
        public void Get_QuandoChamado_RetornaObjectResult()
        {
            var okResult = _controller.Get(1);
            Assert.IsType<ObjectResult>(okResult);
        }

        [Fact]
        public void Get_QuandoChamado_RetornaTodosOsEnderecos()
        {
            var okResult = _controller.GetAll();
            var items = Assert.IsType<List<Endereco>>(((ObjectResult)okResult).Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Get_QuandoChamadoSemParametro_RetornaNotFoundResult()
        {
            var notExistingId = new Random(100).Next();
            var notFoundResult = _controller.Get(notExistingId);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void Get_QuandoChamado_RetornaEndereco()
        {
            var okResult = _controller.Get(1);
            Assert.IsType<Endereco>(((ObjectResult)okResult).Value);
            Assert.Equal(1, ((Endereco)((ObjectResult)okResult).Value).Id);
        }

        [Fact]
        public void Update_PasandoUmObjetoInvalido_RetornaBadRequest()
        {
            var nameMissingItem = new Endereco
            {
                Id = 2,
                Logradouro = "Rua Alterada, 20",
                Bairro = "Novo Bairro B"
            };
            _controller.ModelState.AddModelError("Cidade", "Required");
            _controller.ModelState.AddModelError("Estado", "Required");

            var badResponse = _controller.Put(nameMissingItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Update_PassandoUnObjetoValido_RetornaObjectResult()
        {
            var testItem = new Endereco()
            {
                Id = 2,
                Logradouro = "Rua Alterada, 20",
                Bairro = "Novo Bairro B",
                Cidade = "Nova Cidade B",
                Estado = "Rio de Janeiro"
            };

            var createdResponse = _controller.Put(testItem);
            Assert.IsType<ObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_PassandoUmObjetoValido_RetornaEnderecoAlterado()
        {
            var testItem = new Endereco()
            {
                Id = 2,
                Logradouro = "Rua Alterada, 20",
                Bairro = "Novo Bairro B",
                Cidade = "Nova Cidade B",
                Estado = "São Paulo"
            };

            var createdResponse = _controller.Put(testItem) as ObjectResult;
            var item = createdResponse.Value as Endereco;

            Assert.IsType<Endereco>(item);
            Assert.Equal("Rua Alterada, 20", item.Logradouro);
        }

        [Fact]
        public void Add_PasandoUmObjetoInvalido_RetornaBadRequest()
        {
            var nameMissingItem = new Endereco
            {
                Logradouro = "Rua Nova D, 40",
                Bairro = "Novo Bairro B"
            };
            _controller.ModelState.AddModelError("Cidade", "Required");
            _controller.ModelState.AddModelError("Estado", "Required");

            var badResponse = _controller.Post(nameMissingItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_PassandoUnObjetoValido_RetornaCreatedResponse()
        {
            var testItem = new Endereco()
            {
                Id = 2,
                Logradouro = "Rua Alterada, 20",
                Bairro = "Novo Bairro B",
                Cidade = "Nova Cidade B",
                Estado = "São Paulo"
            };

            var createdResponse = _controller.Post(testItem);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_PassandoUmObjetoValido_RetornaEnderecoCriado()
        {
            var testItem = new Endereco()
            {
                Id = 2,
                Logradouro = "Rua Alterada, 20",
                Bairro = "Novo Bairro B",
                Cidade = "Nova Cidade B",
                Estado = "São Paulo"
            };

            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Endereco;

            Assert.IsType<Endereco>(item);
            Assert.Equal("Rua Alterada, 20", item.Logradouro);
        }

        [Fact]
        public void Remove_PassandoUmIdInvalido_RetornaNotFoundResponse()
        {
            var notExistingId = new Random(100).Next();
            var badResponse = _controller.Delete(notExistingId);
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_PassandoUmIdValido_RetornaNoContentResult()
        {
            var okResponse = _controller.Delete(1);
            Assert.IsType<NoContentResult>(okResponse);
        }
        [Fact]
        public void Remove_PassandoUmIdValido_RemoveUmEndereco()
        {
            var okResponse = _controller.Delete(1);
            Assert.Equal(2, _service.GetAll().Count());
        }
    }
}
