using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Clarika.Examen.Tecnico.Models;
using Clarika.Examen.Tecnico.Views;
using Clarika.Examen.Tecnico.Services.Interfaces;

namespace Clarika.Examen.Tecnico.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {

        public UsersViewModel(IUserService userService)
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());

            ItemTapped = new Command<User>(OnItemSelected);
            _userService = userService;

        }

        public void OnAppearing()
        {


            IsBusy = true;
            SelectedItem = null;
        }


        #region Property

        private User _selectedItem;

        public ObservableCollection<User> Users { get; }

        private IUserService _userService;

        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        #endregion

        #region Command

        public Command LoadUsersCommand { get; }

        public Command<User> ItemTapped { get; }

        #endregion

        #region Private


        async Task ExecuteLoadUsersCommand()
        {
            Error = false;

            try
            {
                var items = await _userService.GetUserAllAsync();
                Users.Clear();

                foreach (var item in items)
                {
                    Users.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Error = true;

            }
            finally
            {
                IsBusy = false;
            }
        }





        async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={item.Id}");
        }

        #endregion



    }
}