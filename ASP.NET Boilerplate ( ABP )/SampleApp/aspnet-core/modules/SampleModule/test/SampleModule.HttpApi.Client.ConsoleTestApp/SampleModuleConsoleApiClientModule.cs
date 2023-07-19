using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SampleModule;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SampleModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SampleModuleConsoleApiClientModule : AbpModule
{

}
