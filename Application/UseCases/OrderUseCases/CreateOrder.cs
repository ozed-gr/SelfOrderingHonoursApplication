using Application.Repositories.MenuItemRepositories;
using AutoMapper;
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

        public Task Execute()
        {
            throw new NotImplementedException();
        }
    }
}
