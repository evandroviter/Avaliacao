using System;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using Icatu.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Icatu.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Endereco item)
        {
            try
            {
                _service.Post<EnderecoValidator>(item);
                return CreatedAtAction("Get", new { id = item.Id }, item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Endereco/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] Endereco item)
        {
            try
            {
                var existing = _service.Get(item.Id);
                if (existing == null)
                    return NotFound();

                _service.Put<EnderecoValidator>(item);
                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _service.Get(id);
                if (item == null)
                    return NotFound();

                _service.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(_service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                var item = _service.Get(id);
                if (item == null)
                    return NotFound();

                return new ObjectResult(item);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}