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
	public partial class Set1_5 : ContentPage
    {
        private string _generalCondition;
        private double _bPressure;
        private double _heartrate;
        private double _breath;
        private double _spO2;
        public Set1_5 (string generalCondition, double bpressure, double heartrate, double breath)
        {
            _generalCondition = generalCondition;
            _bPressure = bpressure;
            _heartrate = heartrate;
            _breath = breath;
            InitializeComponent ();
           
		}
        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_6(_generalCondition, _bPressure, _heartrate, _breath, _spO2));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _spO2 = Convert.ToDouble(e.NewTextValue);
        }
    }
}