using Volo.Abp.Modularity;

namespace Acme.BookStore1;

[DependsOn(
    typeof(BookStore1ApplicationModule),
    typeof(BookStore1DomainTestModule)
    )]
public class BookStore1ApplicationTestModule : AbpModule
{

}
