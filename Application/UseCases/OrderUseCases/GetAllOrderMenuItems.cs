using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public class GetAllOrderMenuItems : IGetAllOrderMenuItems
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public GetAllOrderMenuItems(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task Execute(int p_order_id)
        {
            var allMenuItemsFromOrder = _orderRepository.GetAllOrderMenuItems(p_order_id);

            return Task.FromResult(allMenuItemsFromOrder);
        }
    }
}
