using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Entities;
using Hive.Core.Specifications;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Hive.Application.Services_Specs
{
    public class UserIdSpecification : BaseSpecification<AppUser>
    {
        public UserIdSpecification(object id) : base(u => id == null ||  id == u.Id)
        {
            
        }
    }
}
