using SampleApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SampleApp;

[DependsOn(
    typeof(SampleAppEntityFrameworkCoreTestModule)
    )]
public class SampleAppDomainTestModule : AbpModule
{

}
