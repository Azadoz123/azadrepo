using Allegory.Module.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allegory.Module.EntityFrameworkCore
{
    public static class ModuleEfCoreQueryableExtentions
    {
        public static IQueryable<Customer> IncludeDetails(
            this IQueryable<Customer> queryable,
            bool include = true)
        {
            if(!include) return queryable;

            return queryable
                .Include(x => x.ContactInformations)
                .Include(x => x.Address);
        }
    }
}
