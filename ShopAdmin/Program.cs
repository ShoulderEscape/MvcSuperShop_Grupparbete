using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopGeneral.Data;
using ShopGeneral.Services;
using ShopGeneral.Mailing;
using Microsoft.EntityFrameworkCore;
using ShopGeneral.JsonHandler;
using System.Runtime.CompilerServices;
using ShopGeneral.CategoryValidator;
using ConsoleAppFramework;
using ShopGeneral.Commands;


if (!Directory.Exists(@".\outfiles")) 
{
    Directory.CreateDirectory("outfiles");
}
if (!Directory.Exists(@".\outfiles\pricerunner")) 
{
    Directory.CreateDirectory(@".\outfiles\pricerunner");
}
if (!Directory.Exists(@".\outfiles\category")) 
{
    Directory.CreateDirectory(@".\outfiles\category");
}
if (!Directory.Exists(@".\outfiles\products")) 
{
    Directory.CreateDirectory(@".\outfiles\products");
}

var builder = ConsoleApp.CreateBuilder(args);

builder.ConfigureServices((ctx, services) =>
{
    var connectionString = ctx.Configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    
    services.AddDatabaseDeveloperPageExceptionFilter();


    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();


    services.AddTransient<IAgreementService, AgreementService>();
    services.AddTransient<DataInitializer>();
    // Using Cysharp/ZLogger for logging to file
    //services.AddLogging(logging =>
    //{
    //    logging.AddZLoggerFile("log.txt");
    //});

});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataInitializer = scope.ServiceProvider.GetService<DataInitializer>();
    dataInitializer.SeedData();
}

app.AddAllCommandType();
app.Run();
//generate prices to PriceRunner (JSON file)
//verify all product images exists 
//report categories without products
//report  
