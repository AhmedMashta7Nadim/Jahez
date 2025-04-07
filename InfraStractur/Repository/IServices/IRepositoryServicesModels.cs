using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace InfraStractur.Repository.IServices
{
    public interface IRepositoryServicesModels<T,V,Z>
        where T : class
        where V : class
        where Z : class
    {
        Task<List<TResult>?> GetAllAsync<TResult>(bool IsSummary = false);
        ////////
        ///getById
        ///
        Task<dynamic> GetByIdAsync(string Id,bool IsSummary);
        ////////
        ///get And List
        ////////
        Task<List<TResult>?> GetAllAndList<TResult>(
            string Id,
            bool IsList,
            Func<IQueryable<T>, IQueryable<T>> listFunc
        );
        ////////////
        ///Added Data 
        ///
        Task<T> AddAsync(Z item);
        ///////
        ///Update Data
        ////////
        Task<V> UpdateAsync(JsonPatchDocument<Z>item);
        ////////
        ///SoftDeleted
        ///////
        Task<string> SoftDeleteAsync(string Id);










    }
}
