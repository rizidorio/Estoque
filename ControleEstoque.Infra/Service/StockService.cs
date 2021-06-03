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
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockDto>> GetAll()
        {
            IEnumerable<Stock> stocks = await _repository.GetAll();

            if (!stocks.Any())
            {
                throw new Exception("Não existe estoques cadastrados.");
            }

            return stocks.Select(x => new StockDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity
            });
        }

        public async Task<StockDto> GetById(int id)
        {
            Stock stock = await _repository.GetById(id);

            if (stock is null)
            {
                throw new Exception("Estoque não encontrado.");
            }

            return new StockDto
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }

        public async Task<StockDto> GetByProductId(int productId)
        {
            IEnumerable<StockDto> stocks = await GetAll();

            return stocks.FirstOrDefault(x => x.ProductId.Equals(productId));
        }

        public async Task<StockDto> Insert(StockDto stockDto)
        {
            StockDto exists = await GetByProductId(stockDto.ProductId);

            if (exists is null)
            {
                Stock stock = new Stock(stockDto.Id, stockDto.ProductId, stockDto.Quantity);
                Stock result = await _repository.Insert(stock);

                if (result is null)
                {
                    throw new Exception("Não foi possível lançar o estoque");
                }

                stockDto.Id = result.Id;

                return stockDto;
            }
            else
            {
                throw new Exception("Já existe lançamentos de estoque para este produto.");
            }
        }

        public async Task<StockDto> Update(StockDto stockDto)
        {
            StockDto exists = await GetByProductId(stockDto.ProductId);

            if (exists is null)
            {
                throw new Exception("Não foi possível localizar o estoque.");
            }

            Stock stock = await _repository.GetById(exists.Id);

            stock.Quantity = stockDto.Quantity;

            Stock result = await _repository.Update(stock);

            if (result is null)
            {
                throw new Exception("Erro ao atulizar o estoque");
            }

            return stockDto;
        }
    }
}
