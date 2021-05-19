using System.Threading.Tasks;
using Tindero.Settings;
using Tindero.Views;
using Xamarin.Forms;

namespace Tindero.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        public override async void OnAppearing()
        {
            base.OnAppearing();

            // Simulate authentication check
            await Task.Delay(2143);

            Application.Current.MainPage = new AppShell();

            if (UserSettings.Id > 0)
            {
                await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}
