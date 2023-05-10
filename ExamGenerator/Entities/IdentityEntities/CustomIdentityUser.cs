using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entities.IdentityEntities
{
    public class CustomIdentityUser: IdentityUser, IEntity
    {
    }
}
