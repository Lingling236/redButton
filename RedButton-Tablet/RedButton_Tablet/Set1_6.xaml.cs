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
	public partial class Set1_6 : ContentPage
    {
        private string _generalCondition;
        private double _bPressure;
        private double _heartrate;
        private double _breath;
        private double _spO2;
        private double _bSugar;
        public Set1_6 (string generalCondition, double bpressure, double heartrate, double breath, double spo2)
        {
            _generalCondition = generalCondition;
            _bPressure = bpressure;
            _heartrate = heartrate;
            _breath = breath;
            _spO2 = spo2;
            InitializeComponent ();
           
        }
        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Done_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_total(_generalCondition, _bPressure, _heartrate, _breath, _spO2, _bSugar));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _bSugar = Convert.ToDouble(e.NewTextValue);
        }
    }
}