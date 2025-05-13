using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Interfaces;
using Hive.Core.Specifications;
using Hive.Infrastructure.Data;
using Hive.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Hive.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HiveContext _dbContext;

        public GenericRepository(HiveContext hiveContext)
        {
            _dbContext = hiveContext;
        }



        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specs)
        {
            return await ApplySpecifications(specs).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specs)
        {
            return await ApplySpecifications(specs).CountAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetAsync(ISpecification<T> specs)
        {
            return await ApplySpecifications(specs).FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }


        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

       

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        private  IQueryable<T> ApplySpecifications(ISpecification<T> specs)
        {
            return  SpecificationEvaluator.GetQuery(_dbContext.Set<T>(), specs);
        }
    }
}
