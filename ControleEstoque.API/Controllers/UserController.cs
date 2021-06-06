using ControleEstoque.API.Services;
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
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<UserDto> users = await _service.GetAll();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{code}")]
        [Authorize]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                UserDto user = await _service.GetByCode(code);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] UserDto userDto)
        {
            try
            {
                IEnumerable<UserDto> users = await _service.GetAll();
                UserDto user = users.FirstOrDefault(x => x.Name.Equals(userDto.Name) && x.Password.Equals(userDto.GetHashPassword()));

                if (user is null)
                {
                    return NotFound("Usuário ou senha inválidos.");
                }

                string token = TokenService.GenerateToken(user);
                user.Password = string.Empty;

                return new
                {
                    token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDto result = await _service.Insert(userDto);

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
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDto result = await _service.Update(userDto);

                    return Ok($"Usuário {result.Code} atualizado com sucesso!");
                }

                throw new Exception(string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{code}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                bool result = await _service.Remover(code);

                if (result)
                {
                    return NoContent();
                }

                throw new Exception("Não foi possível apagar o usuário.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

