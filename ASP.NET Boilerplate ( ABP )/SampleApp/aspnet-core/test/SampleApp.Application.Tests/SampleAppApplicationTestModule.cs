using Volo.Abp.Modularity;

namespace SampleApp;

[DependsOn(
    typeof(SampleAppApplicationModule),
    typeof(SampleAppDomainTestModule)
    )]
public class SampleAppApplicationTestModule : AbpModule
{

}
