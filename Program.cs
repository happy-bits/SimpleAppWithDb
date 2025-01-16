using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;

string logFile = "____log.txt";
System.IO.File.AppendAllLines(logFile, [DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "👉 Starting program! " ]);

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add DNS check logging
    try 
    {
        var hostEntry = System.Net.Dns.GetHostEntry("db.ffgugnzpcofosresavnl.supabase.co");
        System.IO.File.AppendAllLines(logFile, [
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + 
            "👉 DNS Resolution successful. IP: " + 
            string.Join(", ", hostEntry.AddressList.Select(ip => ip.ToString()))
        ]);
    }
    catch (Exception dnsEx)
    {
        System.IO.File.AppendAllLines(logFile, [
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + 
            "👉 DNS Resolution failed: " + dnsEx.Message
        ]);
    }

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    System.IO.File.AppendAllLines(logFile, [DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "👉 Connection string: " + builder.Configuration.GetConnectionString("DefaultConnection") ]);

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
    System.IO.File.AppendAllLines(logFile, ["👉 Error: " + ex.Message + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")]);
    throw;
}

