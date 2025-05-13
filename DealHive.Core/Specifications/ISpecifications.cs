﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hive.Core.Specifications
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>>? Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>>? OrderBy { get; }

        Expression<Func<T, object>>? OrderByDescending { get; }

        int Skip { get; }
        int Take { get; }
        bool PaginationEnabled { get; }

        void ApplyPagination(int skip, int take);
    }
}