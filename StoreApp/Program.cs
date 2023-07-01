using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contract;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();


builder.Services.AddSingleton<Cart>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin", 
        areaName: "Admin", 
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
   
    
    endpoints.MapControllerRoute(
        name: "default", 
        pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapRazorPages();
});



app.Run();
