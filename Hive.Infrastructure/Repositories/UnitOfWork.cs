using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Interfaces;
using Hive.Infrastructure.Data;

namespace Hive.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly HiveContext _context;
        private Hashtable? _repositories;
        public UnitOfWork(HiveContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            // Check if the repository exists in the hashtable
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                if (repositoryInstance != null)
                {
                    _repositories.Add(type, repositoryInstance);
                }
                else
                {
                    // Handle the case where Activator.CreateInstance returns null, though unlikely for GenericRepository
                    throw new InvalidOperationException($"Could not create repository instance for {type}");
                }
            }

            return (IGenericRepository<T>)_repositories[type]!;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
