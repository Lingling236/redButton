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
	public partial class Set1_1 : ContentPage
	{
        private string _generalCondition;
		public Set1_1 ()
		{
			InitializeComponent ();
		}
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
       async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_2(_generalCondition));
           // Navigation.RemovePage(this);
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
                _generalCondition = e.NewTextValue;
            else {
                DisplayAlert("Invalid Infomation","","");

            }
        }
    }
}