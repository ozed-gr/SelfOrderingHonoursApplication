using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<IngredientDTO> ItemIngredients { get; set; }

        public MenuItemDTO()
        {

        }

        public MenuItemDTO(string p_name, string p_desc, string p_category, double p_price)
        {
            Name = p_name;
            Description = p_desc;
            Category = p_category;
            Price = p_price;
        }
    }
}
