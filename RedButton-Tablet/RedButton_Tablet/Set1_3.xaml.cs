﻿using System;
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
		public Set1_3 ()
		{
			InitializeComponent ();
		}
        async void Previous_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Set1_4());
        }
    }
}