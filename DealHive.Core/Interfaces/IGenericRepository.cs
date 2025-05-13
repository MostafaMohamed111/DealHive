using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Specifications;

namespace Hive.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(); 
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specs);
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);





    }
}
