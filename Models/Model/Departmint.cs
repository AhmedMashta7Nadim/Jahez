using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Entitys;

namespace Models.Model
{
    public class Departmint:EntityModels
    {
        public required string NameDepartmint { get; set; }
        public required string SectionType { get; set; } //نوع القسم 
        public string Description { get; set; } = string.Empty;
        public DateTime dateTime { get; set; } = DateTime.UtcNow;
        [NotMapped]
        public IFormFile img { get; set; }
        public string Path { get; set; }
        public List<Categorie> categories { get; set; } = new List<Categorie>();

    }
}
