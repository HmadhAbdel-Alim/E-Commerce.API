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
    public class ProductService
    {
        private readonly IGenericRepository<Product> repo;

        public ProductService(IGenericRepository<Product> _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<ProductToReturnDto>> GetAllProductAsync()
        {
            var products = await repo.GetAllAsync();
            if (products == null) { return Enumerable.Empty<ProductToReturnDto>(); }

            var productDto = products.Select(p => new ProductToReturnDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                BrandName = p.ProductBrand!.Name,
                TypeName = p.ProductType!.Name


            }).ToList();

            return productDto;
        }

        public async Task<ProductToReturnDto> GetProductById(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) { throw new Exception("Product Not Found"); }
            var productDto = new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                BrandName = product.ProductBrand!.Name,
                TypeName = product.ProductType!.Name
            };
            return productDto;
        }

        public async Task<ProductToReturnDto> CreateProductAsync(ProductCreateDto dto)
        {

            var product = new Product
            {

                Name = dto.Name,
                Description = dto.Description,
                PictureUrl = dto.PictureUrl,
                Price = dto.Price,
                BrandID = dto.BrandId,
                TypeID = dto.TypeId

            };


            var createproduct = await repo.CreateAsync(product);
            await repo.SaveChangeAsync();
            return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                BrandName = product.ProductBrand!.Name,
                TypeName = product.ProductType!.Name
            };

        }


        public async Task<ProductToReturnDto> UpdateProductAsync(int id,ProductCreateDto dto)
        {
            var product = await repo.GetByIdAsync(id);
            if (product== null) { throw new Exception("Product ID Not found Please Try Again "); }


            product.Name = dto.Name;
            product.Description = dto.Description;
            product.PictureUrl = dto.PictureUrl;
            product.Price = dto.Price;
            product.BrandID = dto.BrandId;
            product.TypeID = dto.TypeId;

            await repo.UpdateAsync(product);
            await repo.SaveChangeAsync();

            return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                BrandName = product.ProductBrand!.Name,
                TypeName = product!.ProductType!.Name
            };

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) { throw new Exception("Product not found"); }

            product.IsDeleted = true;
            product.DeleteAt = DateTime.Now;
            await repo.UpdateAsync(product);
            await repo.SaveChangeAsync();






        }
    }
}
