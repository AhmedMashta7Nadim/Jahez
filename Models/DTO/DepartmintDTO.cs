using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Models.DTO
{
    public class DepartmintDTO
    {
        public required string NameDepartmint { get; set; }
        public required string SectionType { get; set; } //نوع القسم 
        public string Description { get; set; } = string.Empty;
        public IFormFile img { get; set; }
    }
}
