using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SampleApp;

[Dependency(ReplaceServices = true)]
public class SampleAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SampleApp";
}
