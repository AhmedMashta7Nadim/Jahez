using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entitys;

namespace Models.VM
{
    public class DepartmintSummary:EntityModels
    {
        public required string NameDepartmint { get; set; }
        public required string SectionType { get; set; } //نوع القسم 
        public string Description { get; set; } = string.Empty;
        public DateTime dateTime { get; set; }
        public string Path { get; set; }

    }
}
