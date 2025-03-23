using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.IServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Models.Entitys;

namespace InfraStractur.Repository.Services
{
    public class RepositoryServicesModels<T, V, Z>
       : IRepositoryServicesModels<T, V, Z>
        where T : class,IEntityModels
        where V : class
        where Z : class
    {
        private readonly ConnectDataBase context;
        private readonly IMapper mapper;

        public RepositoryServicesModels(
            ConnectDataBase context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<T> AddAsync(Z item)
        {
            if (item == null)
                throw new Exception($"add {item} with null");

            var mapping = mapper.Map<T>(item);
            var add=await context.Set<T>().AddAsync(mapping);
                await context.SaveChangesAsync();
            return add.Entity;
        }

        public async Task<List<TResult>?> GetAllAsync<TResult>(bool IsSummary=false)
        {
            var getAll = await context.Set<T>().ToListAsync();
            if (IsSummary)
            {
                var mapping = mapper.Map<List<V>>(getAll);
                return mapping as List<TResult>;
            }
            return getAll as List<TResult>;
        }
    
        public async Task<dynamic> GetByIdAsync(string Id, bool IsSummary = false)
        {
            var getAll = await context.Set<T>().FirstOrDefaultAsync(x=>x.Id==Id);

            if (getAll == null)
            {
                return null;
            }

            if (IsSummary)
            {
                var mapping = mapper.Map<V>(getAll);
                return mapping;
            }
            return getAll;
        }

        public async Task<string> SoftDeleteAsync(string Id)
        {
            var getAll = await context.Set<T>()
                                      .FirstOrDefaultAsync(x => x.Id == Id)??null;
            return "Deleted";
        }

        public Task<V> UpdateAsync(JsonPatchDocument<Z> item)
        {
            throw new NotImplementedException();
        }
    }
}
