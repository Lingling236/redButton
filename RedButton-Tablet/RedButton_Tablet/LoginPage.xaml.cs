using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedButton_Tablet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Cancel_Clicked(object sender, EventArgs e)
        {
            
        }
        async void Ok_Clicked(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Password.Text))
           
            //    DisplayAlert("Alert", "Please fill in your name and password", "Ok");
            //else { await Navigation.PushAsync(new ConnectingPage()); }
            await Navigation.PushAsync(new ConnectingPage());

        }

         void Entry_Completed(object sender, EventArgs e)
        {

        }
    }
}