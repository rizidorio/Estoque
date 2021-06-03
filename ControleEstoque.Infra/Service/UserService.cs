using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = await _repository.GetAll();

            if (!users.Any())
            {
                throw new Exception("Não existe usuários cadastrados");
            }

            return users.Select(x => new UserDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Password = x.Password,
                Role = x.Role
            });
        }

        public async Task<UserDto> GetByCode(string code)
        {
            User user = await _repository.GetByCode(code);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return new UserDto
            {
                Id = user.Id,
                Code = user.Code,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role
            };
        }

        public async Task<UserDto> Insert(UserDto userDto)
        {
            User user = await _repository.GetByCode(userDto.Code);

            if (user is null)
            {
                user = new User(userDto.Id, userDto.Code, userDto.Name, userDto.GetHashPassword(), userDto.Role);
                User result = await _repository.Insert(user);

                if (result is null)
                {
                    throw new Exception("Não foi possível cadastrar o usuário.");
                }

                userDto.Id = result.Id;
                userDto.Password = result.Password;

                return userDto;
            }
            else
            {
                throw new Exception("Usuário já cadastrado.");
            }
        }

        public async Task<bool> Remover(string code)
        {
            User user = await _repository.GetByCode(code);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            await _repository.Remove(user);
            return true;
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            User user = await _repository.GetByCode(userDto.Code);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            user.Id = userDto.Id;
            user.Code = userDto.Code;
            user.Name = userDto.Name;
            user.Password = userDto.GetHashPassword();
            user.Role = userDto.Role;

            User result = await _repository.Update(user);

            if (result is null)
            {
                throw new Exception("Não foi possível atualizar o Usuário.");
            }

            userDto.Password = user.Password;

            return userDto;
        }
    }
}
