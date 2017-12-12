using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedButton_Tablet.FileHelper
{
    public interface ICamera
    {
        Task BringUpCamera();
        void BringUpPhotoGallery();
    }
}
