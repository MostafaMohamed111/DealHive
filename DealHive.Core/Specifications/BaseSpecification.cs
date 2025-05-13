using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        
        public Expression<Func<T, bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>>? OrderBy { get ; private set ; }
        public Expression<Func<T, object>>? OrderByDescending { get ; private set ; }
        public int Skip { get ; private set ; }
        public int Take { get ; private set ; }
        public bool PaginationEnabled { get ; private set ; }


        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void ApplyPagination(int skip, int take)
        {
            PaginationEnabled = true;
            Skip = skip;
            Take = take;
        }

        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }




    }
}
