using Acme.BookStore1.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.BookStore1;

[DependsOn(
    typeof(BookStore1EntityFrameworkCoreTestModule)
    )]
public class BookStore1DomainTestModule : AbpModule
{

}
