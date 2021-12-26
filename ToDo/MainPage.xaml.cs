using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel(this);
            InitializeComponent();
        }
    }
}
