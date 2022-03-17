using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderItemsDTO
    {
        public int OrderItemsId { get; set; }
        public OrderDTO Order { get; set; }
        public MenuItemDTO MenuItem { get; set; }
        public SauceDTO Sauce { get; set; }
        public int Quantity { get; set; }
    }
}
