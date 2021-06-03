using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<CategoryDto> categorias = await _service.GetAll();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                CategoryDto category = await _service.GetByCode(code);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryDto result = await _service.Insert(categoryDto);

                    return CreatedAtAction(nameof(Get), new { code = result.Code }, result);
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryDto result = await _service.Update(categoryDto);

                    return Ok($"Categoria {result.Code} atualizada com sucesso!");
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                bool result = await _service.Remover(code);
                
                if (result)
                    return NoContent();

                throw new Exception("Não foi possível apagar a categoria.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
