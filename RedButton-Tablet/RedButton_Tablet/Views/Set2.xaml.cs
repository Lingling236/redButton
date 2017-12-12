using RedButton_Tablet.FileHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedButton_Tablet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Set2 : ContentPage
	{
      //  public static Image img;
        public static bool IsCamera;

        public Set2 ()
		{
            //img = new Image()
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    BackgroundColor = Color.Gray
            //};
            InitializeComponent ();
		}
        

        private void Take_Clicked(object sender, EventArgs e)
        {
            IsCamera = true;
            DependencyService.Get<ICameraGallery>().CameraMedia();

        }

        private void Choose_Clicked(object sender, EventArgs e)
        {
            IsCamera = false;
            DependencyService.Get<ICameraGallery>().GalleryMedia();
        }
        public void Cameraimage(byte[] imagesource)
		{
			img.Source = null;
			img.Source = ImageSource.FromStream(() => new MemoryStream(imagesource));
		}

		public void Galleryimage(byte[] imagesource)
		{
			img.Source = null;
			img.Source = ImageSource.FromStream(() => new MemoryStream(imagesource));
		}
    }
}