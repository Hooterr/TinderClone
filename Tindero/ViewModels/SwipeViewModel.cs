using PanCardView.Enums;
using PanCardView.EventArgs;
using System.Threading.Tasks;
using System.Windows.Input;
using Tindero.Api;
using Tindero.Api.Responses;
using Tindero.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace Tindero.ViewModels
{
    public class SwipeViewModel : BaseViewModel
    {
        private readonly IUsersApi _users;
        private int _currentPage = 1;

        public ObservableRangeCollection<UserItem> Items { get; set; }

        public UserItem SelectedUser { get; set; }

        public int SelectedUserIndex { get; set; }

        public ICommand ItemSwipedCommand { get; }

        public ICommand SetNewStatusCommand { get; }

        public SwipeViewModel()
        {
            _users = (IUsersApi)App.ServiceProvider.GetService(typeof(IUsersApi));
            ItemSwipedCommand = new AsyncValueCommand<ItemSwipedEventArgs>(HandleItemSwipedAsync);
            SetNewStatusCommand = new AsyncValueCommand<SwipeStatus>(HandleNewItemStatusAsync);
        }

        private async ValueTask HandleNewItemStatusAsync(SwipeStatus newStatus)
        {
            SelectedUser.Status = newStatus;
            MoveNextIfPossible();
            await LoadMoreIfNeeded();
        }

        private ValueTask HandleItemSwipedAsync(ItemSwipedEventArgs args)
        {
            if (args.Direction == ItemSwipeDirection.Left)
            {
                SelectedUser.Status = SwipeStatus.Nope;
                return LoadMoreIfNeeded();
            }
            else
            {
                SelectedUser.Status = SwipeStatus.Like;
            }
            return new ValueTask();
        }

        public override async void OnAppearing()
        {
            CurrentState = LayoutState.Loading;
            await Task.Run(LoadItemsAsync).ConfigureAwait(false);
            CurrentState = LayoutState.Success;
        }
        
        private async ValueTask LoadItemsAsync()
        {
            if (Items != null)
                return;

            await LoadMoreItemsAsync();
        }

        private async Task LoadMoreItemsAsync()
        {
            var response = await _users.GetUsersAsync(_currentPage).ConfigureAwait(false);
            _currentPage++;

            if (Items == null)
            {
                Items = new ObservableRangeCollection<UserItem>(response.Users);
            }
            else
            {
                Items.AddRange(response.Users);
            }
        }

        private async ValueTask LoadMoreIfNeeded()
        { 
            if (Items.Count - SelectedUserIndex > 2)
            {
                return;
            }

            await LoadMoreItemsAsync();
        }

        private void MoveNextIfPossible()
        {
            if (Items.Count - SelectedUserIndex > 1)
            {
                SelectedUserIndex++;
            }
        }
    }
}