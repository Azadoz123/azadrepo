using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.BookStore1.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore1.EntityFrameworkCore;

public class EntityFrameworkCoreBookStore1DbSchemaMigrator
    : IBookStore1DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookStore1DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookStore1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookStore1DbContext>()
            .Database
            .MigrateAsync();
    }
}
