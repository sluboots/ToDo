using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo.ViewModels;

namespace ToDo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.LoadJSON();
            }
        }

        protected override void OnSleep()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.SaveJSON();
            }
        }

        protected override void OnResume()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.LoadJSON();
            }
        }
    }
}
