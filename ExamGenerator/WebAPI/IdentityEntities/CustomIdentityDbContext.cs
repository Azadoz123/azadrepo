using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Entities
{
    public class CustomIdentityDbContext: IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options): base(options)
        {
            
        }
        public DbSet<CustomIdentityUser> AspNetUsers { get; set; }
    }
}
