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
    public class MeasuresService : IMeasuresService
    {
        private readonly IMeasuresRepository _repository;

        public MeasuresService(IMeasuresRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MeasuresDto>> GetAll()
        {
            IEnumerable<Measures> measures = await _repository.GetAll();

            if (!measures.Any())
            {
                throw new Exception("Não existe unidades de medida cadastradas.");
            }

            return measures.Select(x => new MeasuresDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Initials = x.Initials
            });
        }

        public async Task<MeasuresDto> GetByCode(string code)
        {
            Measures measures = await _repository.GetByCode(code);

            if (measures is null)
            {
                throw new Exception("Unidade de medida não encontrada.");
            }

            return new MeasuresDto
            {
                Id = measures.Id,
                Code = measures.Code,
                Name = measures.Name,
                Initials = measures.Initials
            };
        }

        public async Task<MeasuresDto> Insert(MeasuresDto measuresDto)
        {
            Measures measures = await _repository.GetByCode(measuresDto.Code);

            if (measures is null)
            {
                measures = new Measures(measuresDto.Id, measuresDto.Code, measuresDto.Name, measuresDto.Initials);
                Measures result = await _repository.Insert(measures);

                if (result is null)
                {
                    throw new Exception("Não foi possível cadastrar a unidade de medida.");
                }

                measuresDto.Id = result.Id;

                return measuresDto;
            }
            else
            {
                throw new Exception("Unidade de medida já cadastrada.");
            }
        }

        public async Task<bool> Remover(string code)
        {
            Measures measures = await _repository.GetByCode(code);

            if (measures is null)
            {
                throw new Exception("Unidade de medida não encontrada.");
            }

            await _repository.Remove(measures);
            return true;
        }

        public async Task<MeasuresDto> Update(MeasuresDto measuresDto)
        {
            Measures measures = await _repository.GetByCode(measuresDto.Code);

            if (measures is null)
            {
                throw new Exception("Unidade de medida não encontrada.");
            }

            measures.Name = measuresDto.Name;
            measures.Initials = measuresDto.Initials;
            measures.Inactive = measuresDto.Inactive;

            Measures result = await _repository.Update(measures);

            if (result is null)
            {
                throw new Exception("Não foi possível atualizar a Unidade de medida.");
            }

            measuresDto.Id = result.Id;
            measuresDto.Name = result.Name;
            measuresDto.Initials = measures.Initials;
            measuresDto.Inactive = measures.Inactive;

            return measuresDto;
        }
    }
}
