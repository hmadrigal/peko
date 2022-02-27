using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.ViewModels
{
    public class LogInViewModel : RoutableViewModelBase
    {
        public override string UrlPathSegment => nameof(LogInViewModel);


        public LogInViewModel(IScreen screen) : base(screen)
        {
        }

    }
}
