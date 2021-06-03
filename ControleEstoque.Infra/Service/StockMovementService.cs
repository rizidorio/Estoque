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
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;

        public StockMovementService(IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockMovementDto>> GetAll()
        {
            IEnumerable<StockMovement> stocks = await _repository.GetAll();

            if (!stocks.Any())
            {
                throw new Exception("Não foram encontrados lançamentos no estoque.");
            }

            return stocks.Select(x => new StockMovementDto
            {
                Id = x.Id,
                StokId = x.StokId,
                TypeStokMov = x.TypeStokMov,
                DateMovement = x.DateMovement,
                UserMovementId = x.UserMovementId,
                Quantity = x.Quantity
            });
        }

        public async Task<StockMovementDto> GetById(int id)
        {
            StockMovement stock = await _repository.GetById(id);

            if (stock is null)
            {
                throw new Exception("Lançamento não encontrado.");
            }

            return new StockMovementDto
            {
                Id = stock.Id,
                StokId = stock.StokId,
                TypeStokMov = stock.TypeStokMov,
                DateMovement = stock.DateMovement,
                UserMovementId = stock.UserMovementId,
                Quantity = stock.Quantity
            };
        }

        public async Task<StockMovementDto> Insert(StockMovementDto stockMovementDto)
        {
            StockMovement stock = new StockMovement(stockMovementDto.Id, stockMovementDto.StokId, stockMovementDto.TypeStokMov, stockMovementDto.Quantity, stockMovementDto.DateMovement, stockMovementDto.UserMovementId);
            StockMovement result = await _repository.Insert(stock);

            if (result is null)
            {
                throw new Exception("Não foi possível realizar o lançamento.");
            }

            stockMovementDto.Id = result.Id;
            return stockMovementDto;
        }

        public async Task<IEnumerable<StockMovementDto>> ListByStockId(int stockId)
        {
            var stocks = await GetAll();

            return stocks.Where(x => x.StokId.Equals(stockId));
        }

        public async Task<StockMovementDto> Update(StockMovementDto stockMovementDto)
        {
            var stock = await _repository.GetById(stockMovementDto.Id);

            if (stock is null)
                throw new Exception("Lançamento não encontrado.");

            stock.DateMovement = stockMovementDto.DateMovement;
            stock.Quantity = stockMovementDto.Quantity;
            stock.UserMovementId = stockMovementDto.UserMovementId;
            stock.TypeStokMov = stockMovementDto.TypeStokMov;

            var result = await _repository.Update(stock);

            if (result is null)
                throw new Exception("Erro ao realizar o lançamento.");

            return stockMovementDto;
        }
    }
}
