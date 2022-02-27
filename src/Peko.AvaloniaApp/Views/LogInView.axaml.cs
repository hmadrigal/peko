using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Peko.ViewModels;

namespace Peko.AvaloniaApp.Views
{
    public partial class LogInView : ReactiveUserControl<LogInViewModel>
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
