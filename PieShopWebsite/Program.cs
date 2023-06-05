// load the appsetting.json file and kestrel server
var builder = WebApplication.CreateBuilder(args);

// make sure the app knows MVC, enable MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middlewares
app.UseStaticFiles();

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

// endpoint middleware
app.MapDefaultControllerRoute();

app.Run();
