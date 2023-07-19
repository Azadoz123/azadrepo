using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.Web;

[Dependency(ReplaceServices = true)]
public class SampleMongoAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SampleMongoApp";
}
