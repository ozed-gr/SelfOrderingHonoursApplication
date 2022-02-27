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
    public class ChangeOrderAddMenuItem : IChangeOrderAddMenuItem
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public ChangeOrderAddMenuItem(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task Execute(MenuItemDTO p_menuItem)
        {
            MenuItem menuItem = _mapper.Map<MenuItemDTO, MenuItem>(p_menuItem);

            return _orderRepository.ChangeOrderAddMenuItem(menuItem);
        }
    }
}
