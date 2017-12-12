using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(RedButton_Tablet.UWP.SaveAndSendPro))]
namespace RedButton_Tablet.UWP
{
    class SaveAndSendPro: ISaveAndSendPro
    {
        public bool Exists(string filename)
        {
            return false;
        }

       

        public string ReadText(string filename)
        {
            throw new NotImplementedException("Reading files is not implemented");
        }

        public IEnumerable<string> GetFiles()
        {
            return new string[0];
        }

        public void Delete(string filename)
        {
        }

        public async Task WriteTextAsync(string filename, string code, string age, string gender)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile ProQAFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ProQAFile, code);
            throw new NotImplementedException();
        }

        void ISaveAndSendPro.WriteTextAsync(string filename, string code, string age, string gender)
        {
            throw new NotImplementedException();
        }
    }
}
