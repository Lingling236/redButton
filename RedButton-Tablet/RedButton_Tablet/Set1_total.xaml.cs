using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedButton_Tablet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Set1_total : ContentPage
    {  

        public Set1_total(string generalCondition, double bpressure, double heartrate, double breath, double spo2, double bsugar)
        {


            BindingContext = new Set1 {
                GeneralCondition =generalCondition,
                BloodPressure =bpressure,
                HeartRate =heartrate,
                RespiratoryRate =breath,
                SpO2 =spo2,
                BloodSugar =bsugar};
            


          
            InitializeComponent();
           
           
         //   MessagingCenter.Subscribe<Set1_2, string>(this, Events.BloodPressure, BloodPressureValueChanged);
           
          //  var page3 = new Set1_3();
          //  MessagingCenter.Subscribe<Set1_2, EventArgs>(this, Events.BloodPressure, bloodPressure_TextChanged);


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FunctionsPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
        //public void Subscribe() {
        //    var page = new Set1_2();
        //    MessagingCenter.Subscribe<Set1_2, TextChangedEventArgs>(this, Events.BloodPressure, bloodPressure_TextChanged);



        //}

        //public  void bloodPressure_TextChanged(Set1_2 sender, TextChangedEventArgs e)
        //{
        //    // var page = new Set1_2();
        //    // MessagingCenter.Subscribe<Set1_2, string>(this, Events.BloodPressure, bloodPressure_TextChanged);
        //    bloodPressure.Text = e.NewTextValue.ToString();
        //}
        // private void BloodPressureValueChanged(Set1_2 source, string newValue)
        // {
        //   bloodPressure.Text = newValue;

        //}
    }
}