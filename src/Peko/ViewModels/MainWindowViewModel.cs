using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Windows.Input;

namespace Peko.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {

        public RoutingState Router { get; } = Locator.Current.GetService<RoutingState>();

        public ReactiveCommand<Unit, IRoutableViewModel> GoNextCommand { get; }

        public ReactiveCommand<Unit, Unit> GoBackCommand => Router.NavigateBack;

        public ReactiveCommand<Unit, IRoutableViewModel> GoToCustomerIndexCommand { get; set; }

        public ICommand WindowInitializedCommand { get; set; }

        public MainWindowViewModel()
        {
            GoNextCommand = ReactiveCommand.CreateFromObservable(OnGoNextCommand);
            WindowInitializedCommand = ReactiveCommand.Create(OnWindowInitializedCommand);
            GoToCustomerIndexCommand = ReactiveCommand.CreateFromObservable(OnGoToCustomerIndexCommand);
        }

        private IObservable<IRoutableViewModel> OnGoNextCommand()
            => Router.Navigate.Execute(Locator.Current.GetService<LogInViewModel>());

        private IObservable<IRoutableViewModel> OnWindowInitializedCommand()
            => Router.Navigate.Execute(Locator.Current.GetService<DashboardViewModel>());

        private IObservable<IRoutableViewModel> OnGoToCustomerIndexCommand()
            => Router.Navigate.Execute(Locator.Current.GetService<CustomerIndexViewModel>());


    }
}
