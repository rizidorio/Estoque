using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/measures")]
    public class MeasuresController : Controller
    {
        private readonly IMeasuresService _service;

        public MeasuresController(IMeasuresService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<MeasuresDto> measures = await _service.GetAll();

                return Ok(measures);
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
                MeasuresDto measures = await _service.GetByCode(code);

                return Ok(measures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeasuresDto measuresDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MeasuresDto result = await _service.Insert(measuresDto);

                    return CreatedAtAction(nameof(Get), new { code = measuresDto.Code }, result);
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MeasuresDto measuresDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MeasuresDto result = await _service.Update(measuresDto);

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
                {
                    return NoContent();
                }

                throw new Exception("Não foi possível apagar a unidade de medida.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
