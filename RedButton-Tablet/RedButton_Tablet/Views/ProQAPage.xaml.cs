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
            if (string.IsNullOrWhiteSpace(name) || contentPicker.SelectedIndex == -1 || codePicker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(ageEntry.Text) || gengderPicker.SelectedIndex == -1)

                await DisplayAlert("Lack of information", "please fill up all the fields", "ok");


            string errorMessage = null;
            string content = contentPicker.Items[contentPicker.SelectedIndex];
            string code = codePicker.Items[codePicker.SelectedIndex];
            string gender = gengderPicker.Items[gengderPicker.SelectedIndex];
            string proQA = content + " " + code;

            try
            {
                sasp.WriteTextAsync(nameEntry.Text, proQA, ageEntry.Text, gender);
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if (errorMessage == null)
            {
                await DisplayAlert("Confirm", "Your data has been saved", "ok");
                nameEntry.Text = "";
                contentPicker.SelectedIndex = -1;
                codePicker.SelectedIndex = -1;
                ageEntry.Text = "";
                gengderPicker.SelectedIndex = -1;

            }
            else
            {
                await DisplayAlert("ProQA", errorMessage, "OK");
            }
        }

        private void ContentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                switch (selectedIndex)
                {
                    case 0:
                        {
                            foreach (string code in ProQA.AbdominalPain)
                            {
                                codePicker.Items.Add(code);
                            }
                            break;
                        }
                    case 1:
                        {
                            foreach (string code in ProQA.Allergies)
                            {
                                codePicker.Items.Add(code);
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (string code in ProQA.AnimalBites)
                            {
                                codePicker.Items.Add(code);
                            }
                            break;
                        }

                }



            }
        }
    }
}