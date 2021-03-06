using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IStockMovementService _movementService;

        public ProductController(IProductService service, IStockMovementService movementService)
        {
            _service = service;
            _movementService = movementService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ProductDto> products = await _service.GetAll();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{sku}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string sku)
        {
            try
            {
                ProductDto product = await _service.GetBySku(sku);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDto result = await _service.Insert(productDto);
                    return CreatedAtAction(nameof(Get), new { sku = result.SKU }, result);
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDto result = await _service.Update(productDto);
                    return Ok($"Porduto {result.Name} atualizado com sucesso.");
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{sku}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string sku)
        {
            try
            {
                bool result = await _service.Remover(sku);

                if (result)
                {
                    return NoContent();
                }

                throw new Exception("Não foi possível apagar o produto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
