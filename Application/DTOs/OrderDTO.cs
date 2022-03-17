using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDTO 
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime TimePlaced { get; set; }
        public double Total { get; set; }

        public List<OrderItemsDTO> OrderItemsEntities { get; set; } = new List<OrderItemsDTO>();
        public List<MenuItemDTO> OrderItems { get; set; } = new List<MenuItemDTO>();
        public Dictionary<string, int> ItemQuantity { get; set; }

        public OrderDTO()
        {
            TimePlaced = DateTime.Now;
        }

        public OrderDTO(int t_id)
        {
            TableId = t_id;
            TimePlaced = DateTime.Now;
        }

        //Dictionary<string, int>
        //public void GroupMenuItemQunatity()
        //{
        //    Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
        //    int counter = 0;

        //    foreach (var item in OrderItems)
        //    {
        //        keyValuePairs.Add(counter++, item.Name);
        //    }

        //    Dictionary<string, int> valCount = new Dictionary<string, int>();

        //    foreach (var i in keyValuePairs.Values)
        //    {
        //        if (valCount.ContainsKey(i))
        //        {
        //            valCount[i]++;
        //        }
        //        else
        //        {
        //            valCount[i] = 1;
        //        }
        //    }

        //    ItemQuantity = valCount;
        //}
    }
}
