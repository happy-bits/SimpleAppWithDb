using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;


void Log(string text)
{
    string logFile = "____log.txt";
    var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} 👉 {text}";
    System.IO.File.AppendAllLines(logFile, [message]);
    Console.WriteLine(message);
}

try
{
    Log("Starting program!");

    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    Log($"Environment: {environment}");

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

    builder.Services.AddControllersWithViews();

    var dbPassword = builder.Configuration["DbPassword:"+environment];
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    Log($"Connection string: {connectionString} - innan");

    connectionString = connectionString.Replace("<DbPassword>", dbPassword);

    Log($"Connection string: {connectionString} - efter");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString)
    );



    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
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
    Log($"Error: {ex.Message}");
    throw;
}

