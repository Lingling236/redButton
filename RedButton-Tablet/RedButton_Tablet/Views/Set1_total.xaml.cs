using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RedButton_Tablet.FileHelper;

namespace RedButton_Tablet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Set1_total : ContentPage
    {
        SaveAndSendSet1 sass=new SaveAndSendSet1();
        
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

       async  void ReturnButton_Clicked(object sender, EventArgs e)
        {

         //   Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count-5]);
            
            await Navigation.PopModalAsync();
            
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var bp = Convert.ToDouble(bpEntry.Text);
            var hr = Convert.ToDouble(hrEntry.Text);
            var rr = Convert.ToDouble(rrEntry.Text);
            var sp = Convert.ToDouble(spEntry.Text);
            var bs = Convert.ToDouble(bsEntry.Text);
          String errorMessage = null;
            try
            {
                await sass.Save_Value<Set1>(gcEntry.Text, new Set1
                {
                    GeneralCondition = gcEntry.Text,
                    BloodPressure = bp,
                    HeartRate = hr,
                    RespiratoryRate = rr,
                    SpO2 = sp,
                    BloodSugar = bs
                });
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if (errorMessage == null)
            {
                await DisplayAlert("Confirm", "Your data has been saved", "ok");
                gcEntry.Text = "";
                bpEntry.Text = "";
                hrEntry.Text = "";
                rrEntry.Text = "";
                spEntry.Text = "";
                bsEntry.Text = "";


            }
            else
            {
                await DisplayAlert("Set1", errorMessage, "OK");
            }
           


            
        }

        private void SendButton_Clicked(object sender, EventArgs e)
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