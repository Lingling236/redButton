using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RedButton_Tablet.FileHelper;
using RedButton_Tablet.Views;

namespace RedButton_Tablet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class History_Set1 : ContentPage
	{
        SaveAndSendSet1 sass = new SaveAndSendSet1();
		public History_Set1 ()
		{
			InitializeComponent ();
		}
        protected override  async void OnAppearing()
        {
            historyView.ItemsSource = await sass.GetFilesAsync();
            base.OnAppearing();
        }

        private void historyView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string name = (string)e.SelectedItem;
            Navigation.PushAsync(new Set1HistoryDetail(name));
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

            string filename = (string)((MenuItem)sender).BindingContext;
            sass.Delete_Value(filename);
            RefreshListView();
        }
       async void RefreshListView()
        {
            historyView.ItemsSource =  await sass.GetFilesAsync();
            historyView.SelectedItem = null;
        }

    }
}