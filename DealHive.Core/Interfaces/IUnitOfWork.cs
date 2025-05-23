﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<T> Repository<T>() where T : class ;
        Task<int> Commit();
    }
}
