using ReactiveUI;
using System.Reactive;

namespace Peko.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {

        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNextCommand { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBackCommand => Router.NavigateBack;

        public MainWindowViewModel()
        {
            GoNextCommand = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(Splat.Locator.GetLocator().GetService(typeof(LogInViewModel)) as LogInViewModel)
            );
        }
    }
}
