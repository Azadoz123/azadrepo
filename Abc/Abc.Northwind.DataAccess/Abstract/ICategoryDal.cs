using Abc.Core.Data_Access;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
