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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime TimePlaced { get; set; }
        public double Total { get; set; }

        public List<OrderItems> OrderItems { get; set; }

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

    }
}
