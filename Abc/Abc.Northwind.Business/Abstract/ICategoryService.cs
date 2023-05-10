using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Abstract
{
    public interface ICategoryService
    {

        List<Category> GetAll();
    }
}
