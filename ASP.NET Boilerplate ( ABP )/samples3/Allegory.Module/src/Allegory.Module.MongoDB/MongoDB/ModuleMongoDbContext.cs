using Allegory.Module.Customers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.Module.MongoDB;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public class ModuleMongoDbContext : AbpMongoDbContext, IModuleMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    //IMongoCollection<Customer> Customers => Collection<Customer>();

    //IMongoCollection<CustomerGroup> CustomerGroups => Collection<CustomerGroup>();

    IMongoCollection<Customer> IModuleMongoDbContext.Customers => Collection<Customer>();
    IMongoCollection<CustomerGroup> IModuleMongoDbContext.CustomerGroups => Collection<CustomerGroup>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureModule();
    }
}
