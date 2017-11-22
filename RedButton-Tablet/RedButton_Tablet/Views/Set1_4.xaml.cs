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
	public partial class Set1_4 : ContentPage
    {
        private string _generalCondition;
        private double _bPressure;
        private double _heartrate;
        private double _breath;
       
        public Set1_4 (string generalCondition, double bpressure, double heartrate)
        {
            _generalCondition = generalCondition;
            _bPressure = bpressure;
            _heartrate = heartrate;
           
			InitializeComponent();
           


        }

        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

           


        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_5(_generalCondition, _bPressure, _heartrate, _breath));
           // Navigation.RemovePage(this);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _breath =Convert.ToDouble( e.NewTextValue);
        }
    }
}