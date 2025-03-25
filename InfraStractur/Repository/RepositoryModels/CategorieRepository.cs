using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.Services;
using Models.DTO;
using Models.Model;
using Models.VM;

namespace InfraStractur.Repository.RepositoryModels
{
    public class CategorieRepository : RepositoryServicesModels<Categorie, CategorieSummary, CategorieDTO>
    {
        public CategorieRepository(ConnectDataBase context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
