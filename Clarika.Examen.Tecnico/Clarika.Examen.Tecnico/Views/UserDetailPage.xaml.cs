using Clarika.Examen.Tecnico.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Clarika.Examen.Tecnico.Views
{
    

    public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel _viewModel;
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.ServiceProvider.GetService<UserDetailViewModel>();
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
             _viewModel.OnAppearing();


        }
    }
}