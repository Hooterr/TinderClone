using System;
using System.Threading.Tasks;
using Tindero.Settings;
using Tindero.Views;
using Xamarin.Forms;

namespace Tindero.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked, (_) => !IsBusy);
        }

        private async void OnLoginClicked(object obj)
        {
            IsBusy = true;
            LoginCommand.ChangeCanExecute();

            // Simulate login
            await Task.Delay(1234);
            UserSettings.Id = new Random().Next(1, 12);

            await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");

            IsBusy = false;
            LoginCommand.ChangeCanExecute();
        }
    }
}
