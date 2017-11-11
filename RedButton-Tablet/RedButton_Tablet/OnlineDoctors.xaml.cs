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
    public partial class OnlineDoctors : ContentPage
    {
       
        public OnlineDoctors()
        {
            InitializeComponent();
            image.Source = ImageSource.FromResource("RedButton_Tablet.Images.doctor.jpg");
             




    }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Ok_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FunctionsPage());
        }
    }
}