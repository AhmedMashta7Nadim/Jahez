using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.VM
{
    public class CategorieSummary:EntityModels
    {
        public required string NameCategorie { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime dateTime { get; set; } = DateTime.UtcNow;
        public required string departmintId { get; set; }
    }
}
