using Allegory.SampleMongoApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.SampleMongoApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SampleMongoAppPageModel : AbpPageModel
{
    protected SampleMongoAppPageModel()
    {
        LocalizationResourceType = typeof(SampleMongoAppResource);
    }
}
