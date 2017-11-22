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
	public partial class Set1_2 : ContentPage
	{
        private string _generalCondition;
        private double _bloodPressure;
		public Set1_2 (string generalCondition)
		{
            _generalCondition = generalCondition;
			InitializeComponent ();
		}
       
        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushModalAsync(new Set1_3(_generalCondition, _bloodPressure));
          //  Navigation.RemovePage(this);
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var BP = Convert.ToDouble(e.NewTextValue);
          
                _bloodPressure = Convert.ToDouble(e.NewTextValue);

           // if (!string.IsNullOrWhiteSpace(e.NewTextValue))
           // {
           // }
           

            //   MessagingCenter.Send(this, Events.BloodPressure, e.NewTextValue);

        }

        //private void bpressure_Completed(object sender, EventArgs e)
        //{
        //    var text = ((Entry)sender).Text;
        //    var BP = Convert.ToDouble(text);
        //    if (BP < 80 | BP > 120)
        //    {
        //        DisplayAlert("exceed the range!", "please fill in valid blood pressure", "Ok");
        //        bpressure.Text = null;
        //    }
        //    else
        //    {
        //        _bloodPressure = BP;
        //    }
        //}
    }
}