using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/stock")]
    public class StockController : Controller
    {
        private readonly IStockService _service;

        public StockController(IStockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<StockDto> stocks = await _service.GetAll();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                StockDto stock = await _service.GetById(id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            try
            {
                StockDto stock = await _service.GetByProductId(productId);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockDto stockDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StockDto result = await _service.Insert(stockDto);

                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StockDto stockDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StockDto result = await _service.Update(stockDto);

                    return Ok("Estoque atulizado com sucesso.");
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
