using Tindero.Models;
using Xamarin.CommunityToolkit.UI.Views;

namespace Tindero.ViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        public LayoutState CurrentState { get; set; } = LayoutState.Loading;

        public bool IsBusy { get; set; }

        public string Title { get; set; }

        public virtual void OnAppearing() { }
    }
}
