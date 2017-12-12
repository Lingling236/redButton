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
	public partial class ProQAPage : ContentPage
	{
        SaveAndSendPro sasp = new SaveAndSendPro();
		public ProQAPage ()
		{
           
            InitializeComponent ();
		}

       
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Send_Clicked(object sender, EventArgs e)
        {

        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            if (sasp.Exists(name))
            {
                bool okResponse = await DisplayAlert("ProQA",
                                                     "File " + name +
                                                     " already exists. Replace it?",
                                                     "Yes", "No");
                if (!okResponse)
                    return;
            }
            if(string.IsNullOrWhiteSpace(name)|| String.IsNullOrWhiteSpace(codeEntry.Text)|| string.IsNullOrWhiteSpace(ageEntry.Text)|| gengderPicker.SelectedIndex<0)
            
                await DisplayAlert("Lack of information", "please fill up all the fields", "ok");
              

            string errorMessage = null;

            try
            {
                sasp.WriteTextAsync(nameEntry.Text, codeEntry.Text,ageEntry.Text, gengderPicker.ToString());
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if (errorMessage == null)
            {
                await DisplayAlert("Confirm", "Your data has been saved", "ok");
                nameEntry.Text = "";
                codeEntry.Text = "";
                ageEntry.Text = "";
                gengderPicker.SelectedIndex = -1;
               
            }
            else
            {
                await DisplayAlert("ProQA", errorMessage, "OK");
            }
        }

       

    }
}