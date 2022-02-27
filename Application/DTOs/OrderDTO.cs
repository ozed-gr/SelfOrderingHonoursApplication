using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDTO 
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime TimePlaced { get; set; }
        public double Total { get; set; }

        public List<MenuItemDTO> OrderItems { get; set; }

        public OrderDTO()
        {
            TimePlaced = DateTime.Now;
        }

        public OrderDTO(int t_id)
        {
            TableId = t_id;
            TimePlaced = DateTime.Now;
        }
    }
}
