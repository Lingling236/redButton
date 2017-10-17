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
    public partial class Set1_total : ContentPage
    {
        public Set1_total()
        {
            InitializeComponent();
            BindingContext = new Set1_2();
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}