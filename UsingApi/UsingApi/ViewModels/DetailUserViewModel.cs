using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsingApi.Models;
using Xamarin.Forms;

namespace UsingApi.ViewModels
{
    public class DetailUserViewModel : BaseViewModel

    {
        private UserModel user;

        public UserModel User
        {
            get { return user; }
            set 
            { 
                user = value;
                OnPropertyChanged();
            }
        }
        public INavigation Navigation { get; set; }
        public ICommand GoBackCommand { get; set; }
        public DetailUserViewModel(UserModel userinfo, INavigation navigation)
        {
            User = userinfo;
            Navigation = navigation;
            GoBackCommand = new Command(async () => await GoBack());

        }
        public  async Task GoBack()
        {
            await Navigation.PopAsync();
        }

    }
}
