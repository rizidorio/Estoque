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
    [Route("api/stockMovement")]
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _service;
        private readonly IProductService _productService;

        public StockMovementController(IStockMovementService service, IProductService productService)
        {
            _service = service;
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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

        [HttpGet("listByProduct/{productId}")]
        [Authorize]
        public async Task<IActionResult> ListByStock(int productId)
        {
            try
            {
                IEnumerable<StockMovementDto> stocks = await _service.ListByProductId(productId);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] StockMovementDto stockMovementDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = await _productService.GetById(stockMovementDto.ProductId);
                    setStockMovement(product, stockMovementDto);
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
        [Authorize]
        public async Task<IActionResult> Put([FromBody] StockMovementDto stockMovementDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = await _productService.GetById(stockMovementDto.ProductId);
                    setStockMovement(product, stockMovementDto);

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

        private async void setStockMovement(ProductDto productDto, StockMovementDto stockMovementDto)
        {
            if (stockMovementDto.TypeMovement == "E")
            {
                productDto.Quantity += stockMovementDto.Quantity;
            }
            else
            {
                productDto.Quantity -= stockMovementDto.Quantity;
            }

            await _productService.Update(productDto);
        }
    }
}
