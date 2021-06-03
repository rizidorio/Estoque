using ControleEstoque.Domain.Dto;
using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _repository.GetAll();

            if (!products.Any())
                throw new Exception("Não existe produtos cadastrados.");

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                SKU = x.SKU,
                Name = x.Name,
                Description = x.Description,
                CategoryId = x.CategoryId,
                MeasureId = x.MeasureId,
                Cust = x.Cust,
                ChangeDate = x.ChangeDate,
                UserChangeId = x.UserChangeId,
                Inactive = x.Inactive,
            });
        }

        public async Task<ProductDto> GetBySku(string sku)
        {
            var product = await _repository.GetBySku(sku);

            if (product is null)
                throw new Exception("Produto não encontrado.");

            return new ProductDto
            {
                Id = product.Id,
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                MeasureId = product.MeasureId,
                Cust = product.Cust,
                ChangeDate = product.ChangeDate,
                UserChangeId = product.UserChangeId,
                Inactive = product.Inactive,
            };
        }

        public async Task<ProductDto> Insert(ProductDto productDto)
        {
            var product = await _repository.GetBySku(productDto.SKU);

            if (product is null)
            {
                product = new Product(productDto.Id, productDto.SKU, productDto.Name, productDto.Description, productDto.CategoryId, productDto.MeasureId, productDto.Cust, productDto.ChangeDate, productDto.UserChangeId);
                var result = await _repository.Insert(product);

                if (result is null)
                    throw new Exception("Não foi possível cadastrar o produto.");

                productDto.Id = result.Id;
                return productDto;
            }
            else
                throw new Exception("Produto já cadastrado.");
        }

        public async Task<bool> Remover(string sku)
        {
            var product = await _repository.GetBySku(sku);

            if (product is null)
                throw new Exception("Produto não encontrado.");

            await _repository.Remove(product);
            return true;
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            var product = await _repository.GetBySku(productDto.SKU);

            if (product is null)
                throw new Exception("Produto não encontrado.");

            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;
            product.MeasureId = productDto.MeasureId;
            product.Cust = productDto.Cust;
            product.ChangeDate = productDto.ChangeDate;
            product.UserChangeId = productDto.UserChangeId;
            product.Inactive = productDto.Inactive;

            var result = await _repository.Update(product);

            if (result is null)
                throw new Exception("Não foi possível atualizar o produto.");

            return productDto;
        }
    }
}
