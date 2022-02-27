using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using Peko.ViewModels;
using ReactiveUI;

namespace Peko.AvaloniaApp
{
    public static class StartupExtensions
    {

        public static void AddAvalonia(this IServiceCollection services)
        {
            // View Model Locator
            services.AddSingleton<IDataTemplate, ViewLocator>();

            // Main view 
            services.AddSingleton<Views.MainWindow>();

            // Nested views
            services.AddSingleton<IViewFor<LogInViewModel>, Views.LogInView>();

            // View Models
            services.AddSingleton<ViewModels.MainWindowViewModel>();
            services.AddSingleton<ViewModels.LogInViewModel>();

            // Main App
            services.AddSingleton<App>();
        }

    }
}
