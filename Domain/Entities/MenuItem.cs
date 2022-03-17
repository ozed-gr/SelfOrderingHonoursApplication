using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ItemIngredient> ItemIngredients { get; set; }
        //A menu item can have be in many OrderItems
        public List<OrderItems> OrderItems { get; set; }
        public List<MenuItemSauce> SelectionOfSauces { get; set; }

        public MenuItem()
        {
                
        }

        public MenuItem(int p_id, string p_name, string p_desc, string p_category, double p_price)
        {
            Id = p_id;
            Name = p_name;
            Description = p_desc;
            Category = p_category;
            Price = p_price;
        }
    }
}
