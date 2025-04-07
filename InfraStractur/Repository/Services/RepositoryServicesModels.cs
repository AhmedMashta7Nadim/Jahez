using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.IServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Models.Entitys;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<TResult>?> GetAllAndList<TResult>(
     string Id,
     bool IsList,
     Func<IQueryable<T>, IQueryable<T>>? queryModifier = null
 )
        {
            var query = context.Set<T>().AsQueryable();

            if (queryModifier != null)
            {
                query = queryModifier(query); // مثلاً: Include للعلاقات
            }

            var get = await query.FirstOrDefaultAsync(x => EF.Property<string>(x, "Id") == Id);

            if (get == null)
                return null;

            if (IsList)
            {
                var list = await query
                    .Where(x => EF.Property<string>(x, "Id") == Id)
                    .ToListAsync();

                // إذا كانت T و TResult نفس النوع
                if (typeof(TResult) == typeof(T))
                {
                    return list.Cast<TResult>().ToList();
                }

                // إذا كنت تستخدم AutoMapper
                return list.Select(item => mapper.Map<TResult>(item)).ToList();
            }

            return new List<TResult> { mapper.Map<TResult>(get) };
        }



        public async Task<List<TResult>?> GetAllAsync<TResult>(bool IsSummary=false)
        {
            var getAll = await context.Set<T>()
                .Where(x=>x.IsActive)
                .ToListAsync();
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

            getAll!.IsActive = false;
            await context.SaveChangesAsync();

            return "Deleted";
        }

        public Task<V> UpdateAsync(JsonPatchDocument<Z> item)
        {
            throw new NotImplementedException();
        }
    }
}
