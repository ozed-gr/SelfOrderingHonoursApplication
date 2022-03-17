using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrderUseCases
{
    public interface ICreateOrder
    {
        //create new empty Order
        Task Execute(OrderDTO p_orderDTO);

        Task SaveToDB(OrderDTO p_orderDTO);
    }
}
