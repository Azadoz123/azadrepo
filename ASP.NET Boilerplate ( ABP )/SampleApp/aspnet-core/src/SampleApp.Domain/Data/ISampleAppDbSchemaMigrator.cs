using System.Threading.Tasks;

namespace SampleApp.Data;

public interface ISampleAppDbSchemaMigrator
{
    Task MigrateAsync();
}
