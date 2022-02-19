using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsingApi.Controls;
using UsingApi.Helpers;
using UsingApi.Models;
using UsingApi.Services;
using UsingApi.Utils;
using UsingApi.Views;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace UsingApi.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //Navigation and utils
        public INavigation Navigation { get; set; }
        public ApiService apiService { get; set; }
        public int selectedValue { get; set; }
        List<UserModel> users { get; set; }
        public UserModel userSelected { get; set; }
        //lists

        private GroupUserModel groupObject;
        public GroupUserModel GroupObject
        {
            get { return groupObject; }
            set
            {
                groupObject = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<UserModel> usersCollection;

        public ObservableCollection<UserModel> UsersCollection
        {
            get { return usersCollection; }
            set
            {
                usersCollection = value;
                OnPropertyChanged();
            }
        }
        public MenusHelper MenusHelperObj { get; set; }

        private List<MenusHelper> menuItems;
        public List<MenusHelper> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }            
    

        //COMMANDS
        public ICommand ChangeMenuCommand { get; set; }
        public ICommand SaveLocalDbCommand { get; set; }
        public ICommand CleanLocalDbCommand { get; set; }
        public ICommand SendEmailCommand { get; set; }
        public ICommand GoToDetailsUserCommand { get; set; }
        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;    
            apiService = new ApiService();
            Task.Run(async () => GroupObject = await ApiUtils.GetProductsByPage(apiService, 1)).Wait();
            createcollection();
            createmenus();
            SaveLocalDbCommand = new Command(async () => await SaveLocalDb());
            CleanLocalDbCommand = new Command(async () => await ClenLocalDb());
            SendEmailCommand = new Command<UserModel>(async (P) => await SendEmail(P));
            GoToDetailsUserCommand = new Command<UserModel>(async (P) => await GoToDetailsUser(P));
            ChangeMenuCommand = new Command<MenusHelper>(async (P) => await ChangeMenu(P));
            selectedValue = 1;
            Task.Run(async () => users = await UtilsLocalDatabase.GetAllUsers()).Wait();



        }
        public async Task GoToDetailsUser(UserModel user)
        {
           Task.Run(async () => userSelected = await UtilsLocalDatabase.GetUserById(user.id)).Wait();
            if(userSelected == null)
            {
                DependencyService.Get<IToastMessage>().LongMessage("Sorry this user is not saved in local storage");
                return;

            }
            else
            {
                await Navigation.PushAsync(new DetailUserViewPage(user));
            }

        }
        public async Task SendEmail(UserModel user)
        {
            await Xamarin.Essentials.Email.ComposeAsync(
               "Hi " + user.first_name + " " + user.last_name ,
               "How are You?", user.email);
        }
        public async Task ClenLocalDb()
        {
            Task.Run(async () => users = await UtilsLocalDatabase.GetAllUsers()).Wait();
            if(users.Count == 0)
            {
                DependencyService.Get<IToastMessage>().LongMessage("No data Stored");
                return;
            }
            var a = await Application.Current.MainPage.DisplayAlert("Alert", "¿Do you want delete all local data about users?" ,"ACEPT", "CANCEL");
            if (a)
            {
                try
                {
                    await UtilsLocalDatabase.DeleteUsers();
                    DependencyService.Get<IToastMessage>().LongMessage("The data has been deleted");

                }
                catch (Exception ex)
                {
                    DependencyService.Get<IToastMessage>().LongMessage("Error");

                }


            }

        }
        public async Task SaveLocalDb()
        {
            try
            {
                foreach (var user in UsersCollection)
                {
                    await App.Database.SaveItemAsync<UserModel>(user);

                }
                DependencyService.Get<IToastMessage>().LongMessage("The data has been saved");
            }
            catch (Exception ex)
            {
                var a = await Application.Current.MainPage.DisplayAlert("Alert", "This page has already been saved, go to the next page or delete the local data.", "ACEPT", "CANCEL");


            }


        }
        public async Task ChangeMenu(MenusHelper item)
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync(message: "Loading More Users...", configuration: ConfigurationLoading.materialLoadingDialogConfiguration()))
            {
                if (item.query == selectedValue)
                {
                    return;
                }

                else
                {
                    if (item.id == 0)
                    {
                        MenuItems[1].Color = Color.White;
                        MenuItems[1].isselected = true;
                        MenuItems[1].Size = 10;
                        MenuItems[2].Size = 7;
                        MenuItems[2].Color = Color.LightGray;
                        selectedValue = 1;
                    }
                    else
                    {
                        MenuItems[2].Color = Color.White;
                        MenuItems[2].isselected = true;
                        MenuItems[2].Size = 10;
                        MenuItems[1].Size = 7;
                        MenuItems[1].Color = Color.LightGray;
                        selectedValue = 2;

                    }
                    Task.Run(async () => GroupObject = await ApiUtils.GetProductsByPage(apiService, item.query)).Wait();
                    createcollection();

                }
            }
                
        }
        private void createmenus()
        {
            MenusHelperObj = new MenusHelper();
            MenuItems = MenusHelperObj.creation();
        }

        private void createcollection()
        {
            UsersCollection = new ObservableCollection<UserModel>();
            foreach(var user in GroupObject.data)
            {
                UsersCollection.Add(user);
            }
        }
    }
}
