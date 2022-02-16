using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HardCodedDataSet
{
    public class HardCodeDataRepository
    {
        public List<MenuItem> Menu { get; set; }

        public HardCodeDataRepository()
        {
            Menu = new List<MenuItem>();
            Menu.Add(new MenuItem("Eggs", "2 boiled eggs", 5 ));
        }
    }
}
