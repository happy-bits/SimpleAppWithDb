using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;

// System.IO.File.AppendAllLines("LLLLLLLLOG.txt", ["👉 Starting program! " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")]);

try
{
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Console.WriteLine("👉 Connection string: " + builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.Run();
}
catch (Exception ex)
{
    System.IO.File.AppendAllLines("LLLLLLLLOG.txt", ["👉 Error: " + ex.Message]);
    throw;
}

