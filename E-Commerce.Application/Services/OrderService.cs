
using E_Commerce.Application.DTOs;
using E_Commerce.Application.DTOs.OrderDto;
using E_Commerce.Application.Interface;
using E_Commerce.Domian.Entity;
using E_Commerce.Domian.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class OrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDtos = orders.Select(o => new OrderToReturnDto
            {
                ID= o.Id,
                BuyEmail = o.BuyEmail,
                OrderDate = o.OrderDate,
                ShippingAddress = new AddressDto
                {
                    Street = o.ShippingAdress!.Street,
                    City = o.ShippingAdress.City,
                    State = o.ShippingAdress.State,
                    ZipCode = o.ShippingAdress.ZipCode,
                    Country = o.ShippingAdress.Country
                },
                DeliveryMethodID = o.DeliveryMethodID,
                ShippingPrice = o.DeliveryMethod!.Price,

            }).ToList();
            return orderDtos;
        }
        public async Task<OrderToReturnDto?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
                if (order == null){return null;}
                var orderDtos = new OrderToReturnDto
            {
               ID = order.Id,
                BuyEmail = order.BuyEmail,
                OrderDate = order.OrderDate,
                ShippingAddress = new AddressDto
                {
                    Street = order.ShippingAdress!.Street,
                    City = order.ShippingAdress.City,
                    State = order.ShippingAdress.State,
                    ZipCode = order.ShippingAdress.ZipCode,
                    Country = order.ShippingAdress.Country
                },
                DeliveryMethodID = order.DeliveryMethodID,
                ShippingPrice = order.DeliveryMethod!.Price,

            };
            return orderDtos;
        }
        public async Task<OrderToReturnDto> CreateOrderAsync(OrderCreateDto order)
        {
            if (order == null) { throw new Exception("Order cannot be null"); }
            var orderEntity = new Order
            {
                BuyEmail = order.BuyEmail,
                OrderDate = DateTime.UtcNow,
                ShippingAdress = new Adress
                {
                    Street = order.ShippingAdDress!.Street,
                    City = order.ShippingAdDress.City,
                    State = order.ShippingAdDress.State,
                    ZipCode = order.ShippingAdDress.ZipCode,
                    Country = order.ShippingAdDress.Country
                },
                DeliveryMethodID = order.DeliveryMethodID,
            };
            var orderr = await _orderRepository.CreateAsync(orderEntity);

           var orderDtos = new OrderToReturnDto
            {
                ID = orderr.Id,
                BuyEmail = orderr.BuyEmail,
                OrderDate = orderr.OrderDate,
                ShippingAddress = new AddressDto
                {
                    Street = orderr.ShippingAdress!.Street,
                    City = orderr.ShippingAdress.City,
                    State = orderr.ShippingAdress.State,
                    ZipCode = orderr.ShippingAdress.ZipCode,
                    Country = orderr.ShippingAdress.Country
                },
                DeliveryMethodID = orderr.DeliveryMethodID,
                ShippingPrice = orderr.DeliveryMethod!.Price,
            };
            await _orderRepository.SaveChangeAsync();
            return orderDtos;
        }
        public async Task UpdateOrderAsync(int orderId, OrderCreateDto orderDto)
        {
            var Order = await _orderRepository.GetByIdAsync(orderId);
            if (Order == null) { throw new Exception("Order not found"); }
            Order.BuyEmail = orderDto.BuyEmail;
            Order.ShippingAdress!.Street = orderDto.ShippingAdDress!.Street;
            Order.ShippingAdress.City = orderDto.ShippingAdDress.City;
            Order.ShippingAdress.State = orderDto.ShippingAdDress.State;
            Order.ShippingAdress.ZipCode = orderDto.ShippingAdDress.ZipCode;
            Order.ShippingAdress.Country = orderDto.ShippingAdDress.Country;
            Order.DeliveryMethodID = orderDto.DeliveryMethodID;
            await _orderRepository.UpdateAsync(Order);
            await _orderRepository.SaveChangeAsync();
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            var Order = await _orderRepository.GetByIdAsync(orderId);
            if (Order == null) { throw new Exception("Order not found"); }
            Order.IsDeleted = true;
            Order.DeleteAt = DateTime.UtcNow;
            await _orderRepository.UpdateAsync(Order);
            await _orderRepository.SaveChangeAsync();
        }
    }
}
