using Microsoft.AspNetCore.Identity;
using Peko.Models.Identity.Data;
using ReactiveUI;
using System.Windows.Input;

namespace Peko.ViewModels
{
    public class LogInViewModel : RoutableViewModelBase
    {
        public override string UrlPathSegment => GetSegmentName(nameof(LogInViewModel));

        private readonly UserManager<PekoIdentityUser> _userManager;

        public ICommand LogInCommand { get; }

        public LogInViewModel(IScreen screen, UserManager<PekoIdentityUser> userManager) : base(screen)
        {
            _userManager = userManager;
            LogInCommand = ReactiveCommand.Create(OnLogInCommand);
        }

        private void OnLogInCommand()
        {
            // TODO: Perform credentials validation
            NavigateTo<DashboardViewModel>();

        }
    }
}
