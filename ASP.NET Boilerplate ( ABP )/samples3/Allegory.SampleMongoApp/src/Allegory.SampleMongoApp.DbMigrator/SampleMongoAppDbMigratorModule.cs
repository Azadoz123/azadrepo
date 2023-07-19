using Allegory.SampleMongoApp.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Allegory.SampleMongoApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SampleMongoAppMongoDbModule),
    typeof(SampleMongoAppApplicationContractsModule)
    )]
public class SampleMongoAppDbMigratorModule : AbpModule
{

}
