using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore1.Data;

/* This is used if database provider does't define
 * IBookStore1DbSchemaMigrator implementation.
 */
public class NullBookStore1DbSchemaMigrator : IBookStore1DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
