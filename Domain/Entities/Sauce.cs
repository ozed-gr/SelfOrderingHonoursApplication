using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sauce
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItemSauce> MenuItemSaucesCombination { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public Sauce()
        {

        }

        public Sauce(int p_id, string p_name)
        {
            Id = p_id;
            Name = p_name;
        }

    }
}
