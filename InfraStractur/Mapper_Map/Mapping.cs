using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO;
using Models.Model;
using Models.VM;

namespace InfraStractur.Mapper_Map
{
    public class Mapping:Profile
    {

        public Mapping()
        {
            CreateMap<Departmint,DepartmintSummary>().ReverseMap();
            CreateMap<Departmint,DepartmintDTO>().ReverseMap();
            CreateMap<DepartmintSummary, DepartmintDTO>().ReverseMap();
        }

    }
}
