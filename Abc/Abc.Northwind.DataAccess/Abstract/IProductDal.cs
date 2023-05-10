using Abc.Core.Data_Access;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {
    }
}
