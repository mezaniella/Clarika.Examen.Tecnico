using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Clarika.Examen.Tecnico.Models;
using Clarika.Examen.Tecnico.Services.Interfaces;
using Xamarin.Forms;

namespace Clarika.Examen.Tecnico.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {

        public UserDetailViewModel(IUserService userService)
        {
            _userService = userService;

            LoadUserIdCommand = new Command(async () => await ExecuteLoadUserIdCommand());
            CancelarCommand = new Command(OnCancelarClicked);

        }

        public void OnAppearing()
        {


            IsBusy = true;

        }

        #region Property
        private User _user;

        private string _userId { get; set; }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;

            }
        }

        private IUserService _userService;

        #endregion

        #region Command
        public Command LoadUserIdCommand { get; }

        public Command CancelarCommand { get; }

        #endregion

        #region Private
        async Task ExecuteLoadUserIdCommand()
        {
            await LoadUserId(UserId);

        }
        private async void OnCancelarClicked(object obj)
        {

            await Shell.Current.GoToAsync("..");

        }

        private async Task LoadUserId(string userId)
        {

            Error = false;

            try
            {


                var user = await _userService.GetUserAsync(userId);

                if (user == null)
                {
                    Error = true;
                }
                else
                {
                    User = user;

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to Load Item");
                Error = true;

            }
            finally
            {
                IsBusy = false;

            }


        }


        #endregion






    }
}
