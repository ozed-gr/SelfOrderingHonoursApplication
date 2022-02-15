using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public MenuItem()
        {

        }

        public MenuItem(string p_name, string p_desc, double p_price)
        {
            Name = p_name;
            Description = p_desc;
            Price = p_price;
        }
    }
}
