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
    public partial class FunctionsPage : ContentPage
    {
        public FunctionsPage()
        {
            InitializeComponent();
            
        }

        private void ProQA_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProQA());
        }

        private void Set1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Set1_1());
        }

        private void Set2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Set2());
        }

        private void History_Clicked(object sender, EventArgs e)
        {

        }
    }
}