using Allegory.SampleApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Allegory.SampleApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SampleAppEntityFrameworkCoreModule),
    typeof(SampleAppApplicationContractsModule)
    )]
public class SampleAppDbMigratorModule : AbpModule
{

}
