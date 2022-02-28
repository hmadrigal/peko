using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Peko.ViewModels;

namespace Peko.AvaloniaApp.Views
{
    public partial class DashboardView : ReactiveUserControl<DashboardViewModel>
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
