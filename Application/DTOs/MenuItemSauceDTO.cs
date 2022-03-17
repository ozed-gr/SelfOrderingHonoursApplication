using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MenuItemSauceDTO
    {
        public int MenuItemId { get; set; }
        public int SauceId { get; set; }
        public bool Default { get; set; }
        public SauceDTO Sauce { get; set; }
        public MenuItemDTO MenuItem { get; set; }
    }
}
