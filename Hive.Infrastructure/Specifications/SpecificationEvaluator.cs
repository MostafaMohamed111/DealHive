using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Hive.Infrastructure.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, ISpecification<T> specs) where T : class
        {
            var query = inputQuery;
            if (specs.Criteria != null) 
                query = query.Where(specs.Criteria);

            if (specs.OrderBy != null)
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDescending != null)
                query = query.OrderByDescending(specs.OrderByDescending);

            if (specs.PaginationEnabled)
                query = query.Skip(specs.Skip)
                    .Take(specs.Take);

            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));


            return query;
        }
    }
}
