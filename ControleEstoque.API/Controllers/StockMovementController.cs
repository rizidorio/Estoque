using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/stockMovement")]
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<StockMovementDto> stocks = await _service.GetAll();
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
                StockMovementDto stock = await _service.GetById(id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listByStock/{stockId}")]
        public async Task<IActionResult> ListByStock(int stockId)
        {
            try
            {
                IEnumerable<StockMovementDto> stocks = await _service.ListByStockId(stockId);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockMovementDto stockMovementDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StockMovementDto result = await _service.Insert(stockMovementDto);

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
        public async Task<IActionResult> Put([FromBody] StockMovementDto stockMovementDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StockMovementDto result = await _service.Update(stockMovementDto);

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
