using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Peko.ViewModels;

namespace Peko.AvaloniaApp.Views
{
    public partial class CustomerIndexView : ReactiveUserControl<CustomerIndexViewModel>
    {
        public CustomerIndexView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
