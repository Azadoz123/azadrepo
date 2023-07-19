using Allegory.Module.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.Customers
{
    internal class EfCoreCustomerRepository : EfCoreRepository<IModuleDbContext, Customer, Guid>, ICustomerRepository
    {
        public EfCoreCustomerRepository(IDbContextProvider<IModuleDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(
            Guid? customerGroupId = null, 
            Guid? excludeCustomerId = null, 
            CancellationToken cancellation = default)
        {
            return await(await GetDbSetAsync())
                .WhereIf(customerGroupId.HasValue, customer => customer.CustomerGroupId == customerGroupId)
                .WhereIf(excludeCustomerId.HasValue, customer => customer.Id != excludeCustomerId)
                .LongCountAsync(GetCancellationToken(cancellation));
        }

        public override async Task<IQueryable<Customer>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}
