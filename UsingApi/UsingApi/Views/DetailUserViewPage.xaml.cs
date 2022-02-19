using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsingApi.Models;
using UsingApi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsingApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailUserViewPage : ContentPage
    {
        public DetailUserViewModel viewModel { get; set; }
        public DetailUserViewPage(UserModel user)
        {
            viewModel = new DetailUserViewModel(user, Navigation);
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            this.BindingContext = viewModel;
        }
    }
}