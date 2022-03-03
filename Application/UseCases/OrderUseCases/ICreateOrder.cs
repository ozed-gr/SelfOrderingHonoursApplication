﻿using Application.DTOs;
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
    }
}