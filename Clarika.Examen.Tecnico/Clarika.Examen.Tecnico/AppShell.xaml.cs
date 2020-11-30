using System;
using System.Collections.Generic;
using Clarika.Examen.Tecnico.ViewModels;
using Clarika.Examen.Tecnico.Views;
using Xamarin.Forms;

namespace Clarika.Examen.Tecnico
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UserDetailPage), typeof(UserDetailPage));
          
        }

    }
}
