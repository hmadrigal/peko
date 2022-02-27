using Microsoft.AspNetCore.Identity;
using Peko.Models.Identity.Data;
using ReactiveUI;
using System.Windows.Input;

namespace Peko.ViewModels
{
    public class LogInViewModel : RoutableViewModelBase
    {
        private readonly UserManager<PekoUser> _userManager;

        public override string UrlPathSegment => nameof(LogInViewModel);

        public ICommand LogInCommand { get; }

        public LogInViewModel(IScreen screen, UserManager<PekoUser> userManager) : base(screen)
        {
            _userManager = userManager;
            LogInCommand = ReactiveCommand.Create(OnLogInCommand);
        }

        private void OnLogInCommand()
        {

        }
    }
}
