using ReactiveUI;

namespace Peko.ViewModels
{
    public class DashboardViewModel : RoutableViewModelBase
    {
        public override string UrlPathSegment => GetSegmentName(nameof(DashboardViewModel));

        public DashboardViewModel(IScreen screen) : base(screen)
        {

        }

    }
}
