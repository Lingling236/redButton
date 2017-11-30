using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RedButton_Tablet.FileHelper;

namespace RedButton_Tablet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History_ProQA : ContentPage
    {
        SaveAndSendPro sasp = new SaveAndSendPro();
        public History_ProQA()
        {
            
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            historyView.ItemsSource = sasp.GetFiles();
            base.OnAppearing();
        }


        private void historyView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string name = (string)e.SelectedItem;
            Navigation.PushAsync(new ProQAHistoryDetail(name));

           
        }

       

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            sasp.Delete(filename);
            RefreshListView();
        }
        void RefreshListView()
        {
            historyView.ItemsSource = sasp.GetFiles();
            historyView.SelectedItem = null;
        }



    }
}