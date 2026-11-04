using E_Commerce.Application.DTOs.ProductDto;
using E_Commerce.Application.Interface;
using E_Commerce.Domian.Entity.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class TypeService
    {
        private readonly IGenericRepository<ProductType> repository;
        public TypeService(IGenericRepository<ProductType> _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ProductTypeDto>> GetAllTypeAsync()
        {
            var Type = await repository.GetAllAsync();
            if (Type == null) { return Enumerable.Empty<ProductTypeDto>(); }

            var TypeDto = Type.Select(b => new ProductTypeDto
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
            return TypeDto;
        }

        public async Task<ProductTypeDto> GetTypeByIdAsync(int id)
        {
            var Type = await repository.GetByIdAsync(id);
            if (Type == null) { throw new Exception("Type Id Not found"); }

            var TypeDto = new ProductTypeDto
            {
                Id = Type.Id,
                Name = Type.Name
            };
            return TypeDto;
        }

        public async Task<ProductTypeDto> CreateTypeAsync(ProductTypeDto TypeDto)
        {
            var Type = new ProductType
            {
                Name = TypeDto.Name
            };
            if (Type == null) { throw new Exception("Please return again in another time"); }

            var Typereturn = await repository.CreateAsync(Type);
            await repository.SaveChangeAsync();
            return new ProductTypeDto
            {
                Id = Typereturn.Id,
                Name = Typereturn.Name
            };
        }

        public async Task<ProductTypeDto> UpdateTypeAsync(int id, ProductTypeDto Dto)
        {
            var Type = await repository.GetByIdAsync(id);
            if (Type == null) { throw new Exception("Please return Try in Another Time"); }
            Type.Name = Dto.Name;

            await repository.UpdateAsync(Type);
            await repository.SaveChangeAsync();
            return new ProductTypeDto
            {
                Id = Type.Id,
                Name = Type.Name
            };

        }

        public async Task DeleteTypeAsync(int id)
        {
            var Type = await repository.GetByIdAsync(id);
            if (Type == null) { throw new Exception("Type Id Not Found"); }

            Type.IsDeleted = true;
            Type.DeleteAt = DateTime.Now;
            await repository.UpdateAsync(Type);
            await repository.SaveChangeAsync();
        }
    }
}
