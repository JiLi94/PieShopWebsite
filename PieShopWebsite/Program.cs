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
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//creates an instance of the ShoppingCart class, passing in the sp parameter. This factory method is invoked by the dependency injection container when resolving instances of the IShoppingCart interface.
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
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
app.UseSession();

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

// endpoint middleware, {controller=home}/{action=Index}/{id?}
app.MapDefaultControllerRoute();

//seed database
DbInitializer.Seed(app);
app.Run();
