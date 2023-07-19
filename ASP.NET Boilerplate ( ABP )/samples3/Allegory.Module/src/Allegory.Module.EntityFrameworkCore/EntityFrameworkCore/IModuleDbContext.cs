using Allegory.Module.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.EntityFrameworkCore;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public interface IModuleDbContext : IEfCoreDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<CustomerGroup> CustomersGroup { get;  }

    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
