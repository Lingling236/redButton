﻿using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using RedButton_Tablet.iOS;
using UIKit;
using Xamarin.Forms;
using RedButton_Tablet.FileHelper;

[assembly: Dependency(typeof(Ios_Dependency))]
namespace RedButton_Tablet.iOS
{
	public class Ios_Dependency : ICameraGallery
	{
        Set2 set2;
		public async void CameraMedia()
		{
			var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);
			if (authorizationStatus != AVAuthorizationStatus.Authorized)
			{
				var access = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
				if (access)
				{
					GotAccessToCamera();
				}
			}
			else
			{
				GotAccessToCamera();
			}

		}

		public void GalleryMedia()
		{

			var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.PhotoLibrary, MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary) };
			imagePicker.AllowsEditing = true;

			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;
			while (vc.PresentedViewController != null)
			{
				vc = vc.PresentedViewController;
			}

			vc.PresentViewController(imagePicker, true, null);

			imagePicker.FinishedPickingMedia += (sender, e) =>
			{
				UIImage originalImage = e.Info[UIImagePickerController.EditedImage] as UIImage;
				if (originalImage != null)
				{
					var pngImage = originalImage.AsPNG();
					byte[] myByteArray = new byte[pngImage.Length];
					System.Runtime.InteropServices.Marshal.Copy(pngImage.Bytes, myByteArray, 0, Convert.ToInt32(pngImage.Length));
                     set2 = new Set2();
					set2.Galleryimage(myByteArray);
				}

				Device.BeginInvokeOnMainThread(() =>
						{
							vc.DismissViewController(true, null);
						});
			};
			imagePicker.Canceled += (sender, e) => vc.DismissViewController(true, null);

		}

		private void GotAccessToCamera()
		{
			var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };

			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;
			while (vc.PresentedViewController != null)
			{
				vc = vc.PresentedViewController;
			}

			vc.PresentViewController(imagePicker, true, null);

			imagePicker.FinishedPickingMedia += (sender, e) =>
			{
				UIImage image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));

				UIImage rotateImage = RotateImage(image, image.Orientation);

				rotateImage = rotateImage.Scale(new CGSize(rotateImage.Size.Width, rotateImage.Size.Height), 0.5f);

				var jpegImage = rotateImage.AsJPEG();

				byte[] myByteArray = new byte[jpegImage.Length];
				System.Runtime.InteropServices.Marshal.Copy(jpegImage.Bytes, myByteArray, 0, Convert.ToInt32(jpegImage.Length));

				set2.Cameraimage(myByteArray);

				Device.BeginInvokeOnMainThread(() =>
				{
					vc.DismissViewController(true, null);
				});
			};


			imagePicker.Canceled += (sender, e) => vc.DismissViewController(true, null);
		}

		double radians(double degrees) { return degrees * Math.PI / 180; }

		private UIImage RotateImage(UIImage src, UIImageOrientation orientation)
		{
			UIGraphics.BeginImageContext(src.Size);

			if (orientation == UIImageOrientation.Right)
			{
				CGAffineTransform.MakeRotation((nfloat)radians(90));
			}
			else if (orientation == UIImageOrientation.Left)
			{
				CGAffineTransform.MakeRotation((nfloat)radians(-90));
			}
			else if (orientation == UIImageOrientation.Down)
			{

			}
			else if (orientation == UIImageOrientation.Up)
			{
				CGAffineTransform.MakeRotation((nfloat)radians(90));
			}

			src.Draw(new CGPoint(0, 0));
			UIImage image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}

	}
}
