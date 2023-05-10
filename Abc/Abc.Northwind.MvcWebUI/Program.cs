using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.MvcWebUI.Entities;
using Abc.Northwind.MvcWebUI.Middleware;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
//builder.Services.AddSingleton<ICartService, CartManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<CustomIdentityDbContext>
        (options=>options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"));
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMvc();
//builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

//app.UseFileServer();

//app.UseNodeModules(app.Environment.ContentRootPath);



app.UseSession();

app.MapDefaultControllerRoute();
//name: "default",
//pattern: "{controller=Product}/{action=Index}/{id?}");

//app.MapControllerRoute(name: "default",pattern: "{controller=Product}/{action=Index}");
//app.UseMvc(configureRoutes);

//void configureRoutes(IRouteBuilder routeBuilder)
//{
//    routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
//}
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}/{id?}");
//});
app.Run();
