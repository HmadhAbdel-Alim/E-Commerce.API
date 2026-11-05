using E_Commerce.Application.DTOs.ProductDto;
using E_Commerce.Application.Interface;
using E_Commerce.Domain.Entity.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class BrandService
    {
        private readonly IGenericRepository<ProductBrand> repository;
        public BrandService(IGenericRepository<ProductBrand> _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ProductBrandDto>> GetAllBrandAsync()
        {
            var brand = await repository.GetAllAsync();
            if (brand == null) { return Enumerable.Empty<ProductBrandDto>(); }

            var brandDto = brand.Select(b => new ProductBrandDto
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
            return brandDto;
        }

        public async Task<ProductBrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await repository.GetByIdAsync(id);
            if (brand == null) { throw new Exception("Brand Id Not found"); }

            var BrandDto = new ProductBrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
            return BrandDto;
        }

        public async Task<ProductBrandDto> CreateBrandAsync(ProductBrandDto brandDto)
        {
            var brand = new ProductBrand
            {
                Name = brandDto.Name
            };
            if (brand == null) { throw new Exception("Please return again in another time"); }

            var brandreturn = await repository.CreateAsync(brand);
            await repository.SaveChangeAsync();
            return new ProductBrandDto
            {
                Id = brandreturn.Id,
                Name = brandreturn.Name
            };
        }

        public async Task<ProductBrandDto> UpdateBrandAsync(int id, ProductBrandDto Dto)
        {
            var brand = await repository.GetByIdAsync(id);
            if (brand == null) { throw new Exception("Please return Try in Another Time"); }
            brand.Name = Dto.Name;

            await repository.UpdateAsync(brand);
            await repository.SaveChangeAsync();
            return new ProductBrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };

        }

        public async Task DeleteBrandAsync(int id)
        {
            var brand = await repository.GetByIdAsync(id);
            if (brand == null) { throw new Exception("Brand Id Not Found"); }

            brand.IsDeleted = true;
            brand.DeleteAt = DateTime.Now;
            await repository.UpdateAsync(brand);
            await repository.SaveChangeAsync();
        }
    }
}
