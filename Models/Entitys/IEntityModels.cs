using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entitys
{
    public interface IEntityModels
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
    }
}
