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
	public partial class Set1_3 : ContentPage
    {
        private string _generalCondition;
        private double  _bPressure;
        private double  _heartrate;
		public Set1_3 (string generalCondition, double bpressure)
        {
            _generalCondition = generalCondition;
            _bPressure = bpressure;
			InitializeComponent ();
		}
        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_4(_generalCondition, _bPressure, _heartrate));
        }

      

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _heartrate =Convert.ToDouble( e.NewTextValue);
        }
    }
}