using System;
using System.ComponentModel;
using Tindero.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tindero.Views
{
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel _vm;

        public ProfilePage()
        {
            InitializeComponent();

            _vm = new ProfileViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.OnAppearing();
        }
    }
}