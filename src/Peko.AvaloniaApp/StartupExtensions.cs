using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.AvaloniaApp
{
    public static class StartupExtensions
    {

        public static void AddAvalonia(this IServiceCollection services)
        {
            services.AddSingleton<IDataTemplate, ViewLocator>();

            services.AddSingleton<Views.MainWindow>();
            services.AddSingleton<ViewModels.MainWindowViewModel>();
            services.AddSingleton<App>();
        }

    }
}
