using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Peko.ViewModels;
using Peko.AvaloniaApp.Views;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Peko.AvaloniaApp
{
    public class App : Application
    {
        private readonly IServiceProvider? _serviceProvider;

        public App() : this(null) { }
        public App(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindowViewModel = _serviceProvider?.GetService<MainWindowViewModel>() ?? new MainWindowViewModel();
                var mainWindow = _serviceProvider?.GetService<MainWindow>() ?? new MainWindow();
                mainWindow.DataContext = mainWindowViewModel;
                var locator = _serviceProvider?.GetService<Avalonia.Controls.Templates.IDataTemplate>() ?? new ViewLocator(_serviceProvider!);
                mainWindow.DataTemplates.Add(locator);
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
