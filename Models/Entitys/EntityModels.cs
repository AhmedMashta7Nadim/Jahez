using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entitys
{
    public class EntityModels : IEntityModels
    {
        public string Id { get; set ; }
        public bool IsActive { get; set; } = true;

        public EntityModels()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
