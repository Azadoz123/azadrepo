using Core.Data_Access;
using Entities.Concrete;
using Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAuthDal: IEntityRepository<User>
    {
        User Register(User user, string password);
        User Login(string userName, string password);
        bool UserExist(string userName);
    }
}
