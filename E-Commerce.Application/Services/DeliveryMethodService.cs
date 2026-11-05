using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interface;
using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class DeliveryMethodService
    {
        private readonly IGenericRepository<DeliveryMethod> method;
        public DeliveryMethodService(IGenericRepository<DeliveryMethod>_method)
        {
            method=_method;
        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetAllDeliveryMethodAsync()
        {
            var Delivery = await method.GetAllAsync();
            if (Delivery == null) { return Enumerable.Empty<DeliveryMethodDto>(); }

            var DeliveryDto = Delivery.Select(x => new DeliveryMethodDto
            {
                Id = x.Id,
                ShortName = x.ShortName,
                Description = x.Description,
                Price = x.Price,
                DeliveryTime = x.DeliveryTime
            }).ToList();
            return DeliveryDto;
        }

        public async Task<DeliveryMethodDto> GetDeliveryMethodByIdAsync(int id)
        {
            var delivery = await method.GetByIdAsync(id);
            if (delivery == null) { throw new Exception("Delivery Id Not Found");}

            var DeliveryDto = new DeliveryMethodDto
            {
                Id = delivery.Id,
                ShortName = delivery.ShortName,
                Description = delivery.Description,
                Price = delivery.Price,
                DeliveryTime = delivery.DeliveryTime
            };
            return DeliveryDto;
        }

        public async Task<DeliveryMethodDto> CeateDeliveryMethodAsync(DeliveryMethodDto dto)
        {
            var delivery = new DeliveryMethod
            {

             ShortName = dto.ShortName,
             Description = dto.Description,
             Price = dto.Price,
             DeliveryTime = dto.DeliveryTime
            };
            await method.CreateAsync(delivery);
            await method.SaveChangeAsync();
            return new DeliveryMethodDto
            {
                Id = delivery.Id,
                ShortName = delivery.ShortName,
                Description = delivery.Description,
                Price = delivery.Price,
                DeliveryTime = delivery.DeliveryTime
            };

        }

        public async Task<DeliveryMethodDto> UpdateDeliveryMethodAsync(int id, DeliveryMethodDto dto)
        {
            var delivery = await method.GetByIdAsync(id);
            if (delivery == null) { throw new Exception("Delivery Id Not found"); }

            delivery.ShortName = dto.ShortName;
            delivery.Description = dto.Description;
            delivery.Price = dto.Price;
            delivery.DeliveryTime = dto.DeliveryTime;

            await method.UpdateAsync(delivery);
            await method.SaveChangeAsync();
            return new DeliveryMethodDto
            {
                Id = delivery.Id,
                ShortName = delivery.ShortName,
                Description = delivery.Description,
                Price = delivery.Price,
                DeliveryTime = delivery.DeliveryTime
            };
        }

        public async Task DeleteDeliveryMethodAsync(int id)
        {
            var delivery = await method.GetByIdAsync(id);
            if (delivery == null) { throw new Exception("delivery not found"); }


            delivery.IsDeleted = true;
            delivery.DeleteAt = DateTime.UtcNow;

            await method.UpdateAsync(delivery);
            await method.SaveChangeAsync();
        }
    }
}
