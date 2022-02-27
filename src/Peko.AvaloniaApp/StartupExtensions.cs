using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using Peko.AvaloniaApp.Views;
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

            // View/ViewModel
            services.AddSingleton<IScreen, MainWindowViewModel>();
            services.AddSingleton<LogInViewModel>();
            services.AddSingleton<IViewFor<LogInViewModel>, LogInView>();

            // Main App
            services.AddSingleton<App>();
        }

    }
}
