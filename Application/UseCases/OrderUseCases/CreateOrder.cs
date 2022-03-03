using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public class CreateOrder : ICreateOrder
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public CreateOrder(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task Execute(OrderDTO p_orderDTO)
        {
            //convert p_orderDTO to Order
            //Order order = _mapper.Map<OrderDTO, Order>(p_orderDTO);
            //var order = _mapper.Map<Order>(p_orderDTO);

            Order order = new Order();
            List<OrderItems> orderItemsList = new List<OrderItems>();
            OrderItems orderItem;

            
            order.Id = p_orderDTO.Id;
            order.TableId = p_orderDTO.TableId;
            order.TimePlaced = p_orderDTO.TimePlaced;
            order.Total = p_orderDTO.Total;

            //foreach (var item in p_orderDTO.OrderItems.Select(x => x).Distinct())
            //{
            //    var menuItem = _mapper.Map<MenuItem>(item);
            //    var quant = p_orderDTO.OrderItems.Where(i => i.Id == item.Id).Count();
            //    orderItem = new OrderItems(order, menuItem, quant);
            //    orderItemsList.Add(orderItem);
            //}

            foreach (var item in p_orderDTO.OrderItems.Select(x => x).Distinct())
            {
                var menuItem = _mapper.Map<MenuItem>(item);
                var quant = p_orderDTO.OrderItems.Where(i => i.Id == item.Id).Count();
                orderItem = new OrderItems();
                orderItem.MenuItemId = item.Id;
                orderItem.OrderId = order.Id;
                orderItem.Quantity = quant;
                orderItemsList.Add(orderItem);
                order.Total += item.Price * quant;
            }

            order.OrderItems = orderItemsList;

            _orderRepository.Create(order);

            return Task.FromResult(order);
        }
    }
}
