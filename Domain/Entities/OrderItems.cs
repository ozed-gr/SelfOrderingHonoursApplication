using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; }
        public int? SauceId { get; set; }
        [ForeignKey("SauceId")]
        public Sauce Sauce { get; set; }
        [Column(Order = 5)]
        public int Quantity { get; set; }

        public OrderItems()
        {

        }

        public OrderItems(Order p_order, MenuItem p_menuItem, int p_quantity)
        {
            Order = p_order;
            MenuItem = p_menuItem;
            Quantity = p_quantity;
        }
    }
}
