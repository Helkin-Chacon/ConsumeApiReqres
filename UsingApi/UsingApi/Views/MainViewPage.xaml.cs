using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingApi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsingApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewPage : ContentPage
    {
        public MainViewModel viewModel { get; set; }
        
        public MainViewPage()
        {
            InitializeComponent();
            viewModel = new MainViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = viewModel;
        }
    }
}