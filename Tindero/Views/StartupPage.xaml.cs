using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tindero.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tindero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupPage : ContentPage
    {
        private readonly BaseViewModel vm;
        public StartupPage()
        {
            InitializeComponent();
            vm = new StartupViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }
    }
}