using ReactiveUI;

namespace Peko.ViewModels
{
    public class CustomerIndexViewModel : RoutableViewModelBase
    {
        public override string UrlPathSegment => GetSegmentName(nameof(CustomerIndexViewModel));

        public CustomerIndexViewModel(IScreen screen) : base(screen)
        {

        }

    }
}
