using Clarika.Examen.Tecnico.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clarika.Examen.Tecnico.Views
{
 

    public partial class UsersPage : ContentPage
    {
        UsersViewModel _viewModel;

        public UsersPage()
        {
            try
            {

                InitializeComponent();

                BindingContext = _viewModel = Startup.ServiceProvider.GetService<UsersViewModel>(); 


            }
            catch (Exception e)
            {
              var es =  e.Message;
            }

        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            if(_viewModel.Users == null || !_viewModel.Users.Any())
             _viewModel.OnAppearing();


        }
    }
}