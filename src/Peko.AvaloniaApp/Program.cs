using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Peko.Models.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace Peko.AvaloniaApp
{
    internal class Program
    {

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();


        // Avalonia configuration, don't remove; also used by visual designer.
        internal static AppBuilder BuildAvaloniaApp()
            => BuildAvaloniaApp(default);
        internal static AppBuilder BuildAvaloniaApp(IServiceProvider? serviceProvider)
            =>
                (serviceProvider == null
                    ? AppBuilder.Configure<App>()
                    : AppBuilder.Configure(() =>
                    {
                        var app = serviceProvider.GetService<App>();
                        return app;
                    })
                )
                .UsePlatformDetect()
                .LogToTrace()
                //.LogToDebug()
                .UseReactiveUI()
            ;


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                    services.UseMicrosoftDependencyResolver();

                    services.AddAvalonia();

                    services.AddDbContext<PekoDbContext>(options =>
                    {
                        options.UseSqlite(hostContext.Configuration.GetConnectionString(nameof(PekoDbContext)));
                    });

                    services
                        .AddIdentityCore<PekoIdentityUser>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<PekoDbContext>();

                    services.AddHostedService<AvaloniaHostedService>();

                });

    }
}
