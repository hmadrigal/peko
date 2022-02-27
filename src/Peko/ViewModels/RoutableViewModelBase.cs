using ReactiveUI;

namespace Peko.ViewModels
{
    public abstract class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
    {
        public abstract string UrlPathSegment { get; }

        public virtual IScreen HostScreen { get; }

        public RoutableViewModelBase(IScreen screen) => HostScreen = screen;

    }
}
