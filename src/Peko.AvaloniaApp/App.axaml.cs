using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Peko.ViewModels;
using Peko.AvaloniaApp.Views;
using System;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Peko.AvaloniaApp
{
    public class App : Application
    {

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var locator = Locator.Current;

                var mainWindowViewModel = locator.GetService<MainWindowViewModel>() ?? new MainWindowViewModel();
                var mainWindow = locator.GetService<MainWindow>() ?? new MainWindow();
                mainWindow.DataContext = mainWindowViewModel;
                var dataTemplate = locator.GetService<Avalonia.Controls.Templates.IDataTemplate>() ?? new ViewLocator();
                mainWindow.DataTemplates.Add(dataTemplate);
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
