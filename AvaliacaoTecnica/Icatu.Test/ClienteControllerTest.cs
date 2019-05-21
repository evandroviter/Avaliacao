using Icatu.Application.Controllers;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using Icatu.Test.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Icatu.Test
{
    public class ClienteControllerTest
    {
        private readonly IClienteService _service;
        private readonly ClienteController _controller;

        public ClienteControllerTest()
        {
            _service = new ClienteServiceFake();
            _controller = new ClienteController(_service);
        }


        [Fact]
        public void Get_QuandoChamado_RetornaObjectResult()
        {
            var okResult = _controller.Get(1);
            Assert.IsType<ObjectResult>(okResult);
        }

        [Fact]
        public void Get_QuandoChamado_RetornaTodosOsClientes()
        {
            var okResult = _controller.GetAll();
            var items = Assert.IsType<List<Cliente>>(((ObjectResult)okResult).Value);
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
        public void Get_QuandoChamado_RetornaCliente()
        {
            var okResult = _controller.Get(1);
            Assert.IsType<Cliente>(((ObjectResult)okResult).Value);
            Assert.Equal(1, ((Cliente)((ObjectResult)okResult).Value).Id);
        }

        [Fact]
        public void Update_PasandoUmObjetoInvalido_RetornaBadRequest()
        {
            var nameMissingItem = new Cliente
            {
                Id = 2,
                Cpf = "12345678910",
                Idade = 12
            };
            _controller.ModelState.AddModelError("Nome", "Required");

            var badResponse = _controller.Put(nameMissingItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Update_PassandoUmCpfInvalido_RetornaBadRequest()
        {
            var testItem = new Cliente()
            {
                Id = 2,
                Nome = "José da Silva",
                Cpf = "1459874526",
                Idade = 12
            };

            var badResponse = _controller.Put(testItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Update_PassandoUnObjetoValido_RetornaObjectResult()
        {
            var testItem = new Cliente()
            {
                Id = 2,
                Nome = "José da Silva",
                Cpf = "04495172760",
                Idade = 12
            };

            var createdResponse = _controller.Put(testItem);
            Assert.IsType<ObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_PassandoUmObjetoValido_RetornaClienteAlterado()
        {
            var testItem = new Cliente()
            {
                Id =2,
                Nome = "José da Silva",
                Cpf = "04495172760",
                Idade = 12
            };

            var createdResponse = _controller.Put(testItem) as ObjectResult;
            var item = createdResponse.Value as Cliente;

            Assert.IsType<Cliente>(item);
            Assert.Equal("José da Silva", item.Nome);
        }

        [Fact]
        public void Add_PasandoUmObjetoInvalido_RetornaBadRequest()
        {
            var nameMissingItem = new Cliente
            {
                Cpf = "12345678910",
                Idade = 12
            };
            _controller.ModelState.AddModelError("Nome", "Required");

            var badResponse = _controller.Post(nameMissingItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_PassandoUmCpfInvalido_RetornaBadRequest()
        {
            var testItem = new Cliente()
            {
                Nome = "José da Silva",
                Cpf = "1459874526",
                Idade = 12
            };

            var badResponse = _controller.Post(testItem);
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_PassandoUnObjetoValido_RetornaCreatedResponse()
        {
            var testItem = new Cliente()
            {
                Nome = "José da Silva",
                Cpf = "04495172760",
                Idade = 12
            };

            var createdResponse = _controller.Post(testItem);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_PassandoUmObjetoValido_RetornaClienteCriado()
        {
            var testItem = new Cliente()
            {
                Nome = "José da Silva",
                Cpf = "04495172760",
                Idade = 12
            };

            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Cliente;

            Assert.IsType<Cliente>(item);
            Assert.Equal("José da Silva", item.Nome);
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
        public void Remove_PassandoUmIdValido_RemoveUmCliente()
        {
            var okResponse = _controller.Delete(1);
            Assert.Equal(2, _service.GetAll().Count());
        }
    }
}
