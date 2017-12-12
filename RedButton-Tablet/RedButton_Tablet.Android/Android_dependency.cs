using System;
using Android.App;
using Android.Content;
using Android.Provider;
using Xamarin.Forms;
using RedButton_Tablet.FileHelper;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using RedButton_Tablet.Droid;
using System.IO;

[assembly: Dependency(typeof(Android_dependency))]
namespace RedButton_Tablet.Droid
{
	public class Android_dependency : ICameraGallery
	{
		public void CameraMedia()
		{

            AppClass._dir = new Java.IO.File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "RedButton");
            if (!AppClass._dir.Exists())
			{
				AppClass._dir.Mkdirs();
			}

			Intent intent = new Intent(MediaStore.ActionImageCapture);

			AppClass._file = new Java.IO.File(AppClass._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));

			intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(AppClass._file));

			Activity activity = (Activity)Forms.Context;
			activity.StartActivityForResult(intent, 0);
		}

		public void GalleryMedia()
		{
			var imageIntent = new Intent();
			imageIntent.SetType("image/*");
			imageIntent.SetAction(Intent.ActionGetContent);
			((Activity)Forms.Context).StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 1);
		}
	}

}
