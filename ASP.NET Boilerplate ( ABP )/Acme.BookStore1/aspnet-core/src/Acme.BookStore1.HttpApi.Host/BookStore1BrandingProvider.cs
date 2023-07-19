using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.BookStore1;

[Dependency(ReplaceServices = true)]
public class BookStore1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookStore1";
}
