using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Tindero.Api;
using Tindero.Api.Responses;
using Tindero.Settings;
using Tindero.Views;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Tindero.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IUsersApi _users;

        public UserItem Profile { get; private set; }

        public ICommand LogoutCommand { get; private set; }

        public ProfileViewModel()
        {
            _users = (IUsersApi)App.ServiceProvider.GetService(typeof(IUsersApi));
            LogoutCommand = new Command(LogoutAsync);
        }

        private async void LogoutAsync(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public override async void OnAppearing()
        {
            CurrentState = LayoutState.Loading;
            // Simulate loading
            await Task.Delay(2213);
            await Task.Run(LoadProfileAsync).ConfigureAwait(false);
            CurrentState = LayoutState.Success;
        }

        private async Task LoadProfileAsync()
        {
            Profile = (await _users.GetUserAsync(UserSettings.Id).ConfigureAwait(false)).Data;
        }
    }
}
