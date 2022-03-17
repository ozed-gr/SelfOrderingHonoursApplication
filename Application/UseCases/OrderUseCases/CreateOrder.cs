using Application.DTOs;
using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Application.UseCases.OrderUseCases
{
    public class CreateOrder : ICreateOrder
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        //private Order order = new Order();

        public CreateOrder(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task Execute(OrderDTO p_orderDTO)
        {
            //Remove all elements and start from scratch in creating the order
            p_orderDTO.OrderItemsEntities.Clear();

            //Loop MenuItem List and create an OrderItems object
            foreach (var item in p_orderDTO.OrderItems)
            {         
                //if MenuItemDTO is in order.OrderItems, then increase quantity and don't create object
                if(p_orderDTO.OrderItemsEntities.Where(x => x.MenuItem.Id == item.Id).Where(y => y.Sauce.Id == item.Sauce.Id).Any())
                {
                    //get index of existing object
                    var index = p_orderDTO.OrderItemsEntities.Select((value, index) => new { value, index })
                            .Where(pair => pair.value.MenuItem.Id == item.Id)
                            .Where(pair => pair.value.Sauce.Id == item.Sauce.Id)
                            .Select(x => x.index)
                            .First();
                    //increase quantity
                    p_orderDTO.OrderItemsEntities[index].Quantity++;
                }
                else
                {
                    //Create OrderItem object
                    p_orderDTO.OrderItemsEntities.Add(new OrderItemsDTO { MenuItem = item, Sauce = item.Sauce, Quantity = 1 });
                }
            }

            return Task.CompletedTask;
        }

        public Task SaveToDB(OrderDTO p_orderDTO)
        {
            Order order = _mapper.Map<Order>(p_orderDTO);

            foreach(var orderItem in order.OrderItems)
            {
                order.Total = order.Total + (orderItem.MenuItem.Price * orderItem.Quantity);
            }

            _orderRepository.Create(order);

            return Task.CompletedTask;
        }
    }
}
