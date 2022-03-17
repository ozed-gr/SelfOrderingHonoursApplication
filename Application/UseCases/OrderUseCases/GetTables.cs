using Application.Repositories.MenuItemRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public class GetTables
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public GetTables(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public int[] Execute()
        {
           return _orderRepository.GetTables();
        }
    }
}
