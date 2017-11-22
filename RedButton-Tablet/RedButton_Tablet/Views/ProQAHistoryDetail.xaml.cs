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
    public partial class ProQAHistoryDetail : ContentPage
    {
        SaveAndSendPro sasp = new SaveAndSendPro();
        public ProQAHistoryDetail(string name)
        {
            
            InitializeComponent();
            label.Text = name;
            editor.Text = sasp.ReadText(name);
        }

        protected override void OnAppearing()
        {
           
            base.OnAppearing();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}