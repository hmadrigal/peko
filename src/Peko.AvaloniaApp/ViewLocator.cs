using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Peko.ViewModels;
using Splat;
using System;

namespace Peko.AvaloniaApp
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);


            if (type == null)
                return new TextBlock { Text = "Not Found: " + name };

            var locator = Locator.Current;
            var control = locator.GetService(type) ?? Activator.CreateInstance(type);

            return (Control)control!;
        }

        public bool Match(object data)
            => data is ViewModelBase;
    }
}
