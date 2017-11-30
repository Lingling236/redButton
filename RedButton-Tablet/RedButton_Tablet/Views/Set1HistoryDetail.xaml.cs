using RedButton_Tablet.FileHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedButton_Tablet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Set1HistoryDetail : ContentPage
    {
        SaveAndSendSet1 sass = new SaveAndSendSet1();
        string FileName;
        public Set1HistoryDetail(string filename)
        {
            InitializeComponent();
            label.Text = filename;
            FileName = filename;
            
        }
        protected async override void OnAppearing()
        {
            Set1 set1 =await sass.Get_Value<Set1>(FileName);
            BindingContext = set1;
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}