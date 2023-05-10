using Microsoft.AspNetCore.Identity;

namespace Core6_App.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
