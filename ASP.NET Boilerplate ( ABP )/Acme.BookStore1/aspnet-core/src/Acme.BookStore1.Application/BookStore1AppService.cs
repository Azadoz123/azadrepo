using System;
using System.Collections.Generic;
using System.Text;
using Acme.BookStore1.Localization;
using Volo.Abp.Application.Services;

namespace Acme.BookStore1;

/* Inherit your application services from this class.
 */
public abstract class BookStore1AppService : ApplicationService
{
    protected BookStore1AppService()
    {
        LocalizationResource = typeof(BookStore1Resource);
    }
}
