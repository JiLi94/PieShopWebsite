// load the appsetting.json file and kestrel server
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;
using PieShopWebsite.Models;

var builder = WebApplication.CreateBuilder(args);

// AddScopes: singloten per request
// register service
// dependency injection
// builder.Services.AddScoped<IMyDependency, MyDependency>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

// make sure the app knows MVC, enable MVC
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
});

var app = builder.Build();

// Middlewares
app.UseStaticFiles();

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

// endpoint middleware
app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
