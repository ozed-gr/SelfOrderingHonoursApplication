using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime TimePlaced { get; set; }
        public double Total { get; set; }

        //An order can have a list of orderItems
        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public Order()
        {
            TimePlaced = DateTime.Now;
        }

        public Order(int o_id, int t_id)
        {
            Id = o_id;
            TableId = t_id;
            TimePlaced = DateTime.Now;
        }

        public Order(int p_id, int p_tid, DateTime p_time, double p_total)
        {

        }

    }
}
