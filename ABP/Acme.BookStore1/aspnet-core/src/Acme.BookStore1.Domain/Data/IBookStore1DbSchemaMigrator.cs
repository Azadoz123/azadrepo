using System.Threading.Tasks;

namespace Acme.BookStore1.Data;

public interface IBookStore1DbSchemaMigrator
{
    Task MigrateAsync();
}
