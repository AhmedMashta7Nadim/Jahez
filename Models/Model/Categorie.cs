using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.Model
{
    public class Categorie:EntityModels
    {
        public required string NameCategorie { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime dateTime { get; set; } = DateTime.UtcNow;
        public required string departmintId { get; set; }
        public Departmint? departmint { get; set; }
        public List<User> users { get; set; } = new List<User>();

    }
}
