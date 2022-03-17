using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TableDTO
    {
        [Required]
        [Range(1, 10, ErrorMessage = "Accommodation invalid (1-10).")]
        public int TableId { get; set; }
        public string Location { get; set; }
    }
}
