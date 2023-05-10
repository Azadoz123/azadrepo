using Acme.BookStore1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookStore1Controller : AbpControllerBase
{
    protected BookStore1Controller()
    {
        LocalizationResource = typeof(BookStore1Resource);
    }
}
