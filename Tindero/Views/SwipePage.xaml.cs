using Tindero.ViewModels;
using Xamarin.Forms;

namespace Tindero.Views
{
    public partial class SwipePage : ContentPage
    {
        private readonly SwipeViewModel _viewModel;

        public SwipePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SwipeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}