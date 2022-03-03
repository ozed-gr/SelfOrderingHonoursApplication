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

            //Mapping manually 
            Order order = new Order();
            List<OrderItems> orderItemsList = new List<OrderItems>();
            OrderItems orderItem;

            
            order.Id = p_orderDTO.Id;
            order.TableId = p_orderDTO.TableId;
            order.TimePlaced = p_orderDTO.TimePlaced;
            order.Total = p_orderDTO.Total;


            //Select distinct menu items and count quantity to create OrderItems record
            foreach (var item in p_orderDTO.OrderItems.Select(x => x.Id).Distinct())
            {
                MenuItemDTO currentMenuItem = p_orderDTO.OrderItems[item];
                var menuItem = _mapper.Map<MenuItem>(currentMenuItem);
                var quant = p_orderDTO.OrderItems.Where(i => i.Id == currentMenuItem.Id).Count();
                orderItem = new OrderItems();
                orderItem.MenuItemId = currentMenuItem.Id;
                orderItem.OrderId = order.Id;
                orderItem.Quantity = quant;
                orderItemsList.Add(orderItem);
                order.Total += currentMenuItem.Price * quant;
            }

            order.OrderItems = orderItemsList;

            _orderRepository.Create(order);

            return Task.FromResult(order);
        }
    }
}
