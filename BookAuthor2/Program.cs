using DAL.DataContext;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Injecting dbcontext using dependency injection


builder.Services.AddTransient<DataSeeder>();

builder.Services.AddDbContext<BookManagementContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB"))
);

void seedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

//services cors


var app = builder.Build();

seedData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseCors(
//options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()

);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
