using System;
using RedButton_Tablet.FileHelper;
using Xamarin.Forms;
using AVFoundation;

[assembly: Dependency(typeof(RedButton_Tablet.iOS.CameraIOS))]
namespace RedButton_Tablet.iOS
{

    class CameraIOS : ICamera
    {
        async System.Threading.Tasks.Task ICamera.BringUpCamera()
        {
            var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            //If we don't have access, and have never asked before, prompt them
            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                var access = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);

                //If access was granted we can proceed, if not, you can add an else statement and implement an error message or something more helpful
                if (access)
                {
                    GotAccessToCamera();
                }
            }
            else
            {
                //We've already been given access
                GotAccessToCamera();
            }
        }

        private void GotAccessToCamera()
        {
            throw new NotImplementedException();
        }

        void ICamera.BringUpPhotoGallery()
        {
            throw new NotImplementedException();
        }
    }
}