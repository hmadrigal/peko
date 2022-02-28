using ReactiveUI;
using Splat;

namespace Peko.ViewModels
{
    public abstract class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
    {
        protected virtual RoutingState Router => HostScreen.Router;

        public abstract string UrlPathSegment { get; }

        public virtual IScreen HostScreen { get; }

        public RoutableViewModelBase(IScreen screen)
        {
            HostScreen = screen;
        }

        public void NavigateTo<TViewModel>() where TViewModel : class, IRoutableViewModel
            => Router.Navigate.Execute(Locator.Current.GetService<TViewModel>());

        protected string GetSegmentName(string segment)
            => string.IsNullOrEmpty(segment)
            ? string.Empty
            : segment.EndsWith("ViewModel", System.StringComparison.InvariantCultureIgnoreCase)
            ? segment.Substring(0, segment.Length - 9).ToUpperInvariant()
            : segment;
    }
}
