using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Peko.ViewModels;
using System;

namespace Peko.AvaloniaApp
{
    public class ViewLocator : IDataTemplate
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);


            if (type == null)
                return new TextBlock { Text = "Not Found: " + name };

            var control = _serviceProvider?.GetService(type) ?? Activator.CreateInstance(type);

            return (Control)control!;
        }

        public bool Match(object data)
            => data is ViewModelBase;
    }
}
