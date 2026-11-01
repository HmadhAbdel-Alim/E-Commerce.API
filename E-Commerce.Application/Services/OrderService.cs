
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
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;
        private readonly IBasketRepository redis;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<DeliveryMethod> deliveryMethodRepository, IBasketRepository basketRepository)
        {
            _orderRepository = orderRepository;
            _deliveryMethodRepository = deliveryMethodRepository;
            redis = basketRepository;
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
            var basket = await redis.GetBasketAsync(order.BasketId);
            if (basket == null) { throw new Exception("Basket not found"); }


            var items = new List<OrderItems>();
            foreach(var item in basket.Items)
            {
                var productItem = new ProductItemOrdered
                {
                    ProductItemId = item.ProductId,
                    ProductName = item.ProductName,
                    PictureUrl = item.PictureUrl
                };
                var orderItem = new OrderItems(productItem, item.Price, item.Quantity);

                items.Add(orderItem);
            }
            var deliveryMethod = await _deliveryMethodRepository.GetByIdAsync(order.DeliveryMethodID);

            var subtotal = items.Sum(i => i.Price * i.Quantity);
            var ShippingAddress = new Adress
            {
                Street = order.ShippingAddress!.Street,
                City = order.ShippingAddress.City,
                State = order.ShippingAddress.State,
                ZipCode = order.ShippingAddress.ZipCode,
                Country = order.ShippingAddress.Country
            };
            var createdorder = new Order(items, subtotal, deliveryMethod, order.BuyEmail, ShippingAddress,basket.PaymentIntentId);
            await _orderRepository.CreateAsync(createdorder);
            var result = await _orderRepository.SaveChangeAsync();

            if (result <= 0) { throw new Exception("Problem creating order"); }

            await redis.DeleteBasketAsync(order.BasketId);
            var orderToReturn = new OrderToReturnDto
            {
                ID = createdorder.Id,
                BuyEmail = createdorder.BuyEmail,
                OrderDate = createdorder.OrderDate,
                ShippingAddress = new AddressDto
                {
                    Street = createdorder.ShippingAdress!.Street,
                    City = createdorder.ShippingAdress.City,
                    State = createdorder.ShippingAdress.State,
                    ZipCode = createdorder.ShippingAdress.ZipCode,
                    Country = createdorder.ShippingAdress.Country
                },
                DeliveryMethodID = createdorder.DeliveryMethodID,
                ShippingPrice = createdorder.DeliveryMethod!.Price,
            };

            return orderToReturn;



        }
        public async Task UpdateOrderAsync(int orderId, OrderCreateDto orderDto)
        {
            var Order = await _orderRepository.GetByIdAsync(orderId);
            if (Order == null) { throw new Exception("Order not found"); }
            Order.BuyEmail = orderDto.BuyEmail;
            Order.ShippingAdress!.Street = orderDto.ShippingAddress!.Street;
            Order.ShippingAdress.City = orderDto.ShippingAddress.City;
            Order.ShippingAdress.State = orderDto.ShippingAddress.State;
            Order.ShippingAdress.ZipCode = orderDto.ShippingAddress.ZipCode;
            Order.ShippingAdress.Country = orderDto.ShippingAddress.Country;
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
