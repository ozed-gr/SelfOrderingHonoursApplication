using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MenuItemSauce
    {
        [Key]
        [Column(Order = 1)]
        public int MenuItemId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SauceId { get; set; }
        [Column(Order = 3)]
        public bool Default { get; set; }
        [ForeignKey("SauceId")]
        public Sauce Sauce { get; set; }
        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; }

        public MenuItemSauce()
        {

        }

        public MenuItemSauce(int p_menuItem_id, int p_sauce_id, bool p_default)
        {
            MenuItemId = p_menuItem_id;
            SauceId = p_sauce_id;
            Default = p_default;
        }
    }
}
