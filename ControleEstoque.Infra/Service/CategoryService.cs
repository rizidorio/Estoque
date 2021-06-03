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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            IEnumerable<Category> categories = await _repository.GetAll();

            if (!categories.Any())
            {
                throw new Exception("Não exite categorias cadastradas.");
            }

            return categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Inactive = x.Inactive,
            });
        }

        public async Task<CategoryDto> GetByCode(string code)
        {
            Category category = await _repository.GetByCode(code);

            if (category is null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            return new CategoryDto
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name,
                Inactive = category.Inactive,
            };
        }

        public async Task<CategoryDto> Insert(CategoryDto categoryDto)
        {
            Category category = await _repository.GetByCode(categoryDto.Code);

            if (category is null)
            {
                category = new Category(categoryDto.Id, categoryDto.Code, categoryDto.Name);
                Category result = await _repository.Insert(category);

                if (result is null)
                {
                    throw new Exception("Não foi possível cadastrar a categoria.");
                }
                categoryDto.Id = result.Id;

                return categoryDto;
            }
            else
            {
                throw new Exception("Categoria já cadastrada.");
            }
        }

        public async Task<bool> Remover(string code)
        {
            Category category = await _repository.GetByCode(code);

            if (category is null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            await _repository.Remove(category);
            return true;
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            Category category = await _repository.GetByCode(categoryDto.Code);

            if (category is null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            category.Id = categoryDto.Id;
            category.Name = categoryDto.Name;
            category.Inactive = categoryDto.Inactive;

            Category result = await _repository.Update(category);

            if (result is null)
            {
                throw new Exception("Não foi possível atualizar a categoria.");
            }

            categoryDto.Id = result.Id;
            categoryDto.Name = result.Name;
            categoryDto.Inactive = result.Inactive;

            return categoryDto;
        }
    }
}
