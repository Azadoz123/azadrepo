using Core6_App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppIdentityDbContext>(option => option.UseSqlServer());
//var dbConnectionString = builder.Configuration.GetSection("DbConnection").Value;

var _configuration = builder.Configuration;

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnectionString"));
    options.UseSqlServer(_configuration["DbConnection"]);

});

builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequireUppercase = true;

    option.Lockout.MaxFailedAccessAttempts = 5;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    option.Lockout.AllowedForNewUsers = true;

    option.User.RequireUniqueEmail = true;

    option.SignIn.RequireConfirmedEmail = true;
    option.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath= "/Security/Login";
    option.LogoutPath = "/Security/Logout";
    option.AccessDeniedPath = "/Security/AccessDenied";
    option.SlidingExpiration = true;
    option.Cookie = new CookieBuilder
    {
       HttpOnly = true,
       Name = ".AspNetCoreDemo.Security.Cookie",
       Path = "/",
       SameSite = SameSiteMode.Lax,
       SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
