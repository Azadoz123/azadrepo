using Acme.BookStore1.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.BookStore1.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStore1EntityFrameworkCoreModule),
    typeof(BookStore1ApplicationContractsModule)
    )]
public class BookStore1DbMigratorModule : AbpModule
{

}
