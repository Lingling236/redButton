using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedButton_Tablet
{
    class SaveAndSendPro : ISaveAndSendPro
    {
        ISaveAndSendPro saveHelper = DependencyService.Get<ISaveAndSendPro>();
        public void Delete(string filename)
        {
            saveHelper.Delete(filename);
        }

        public bool Exists(string filename)
        {
            return saveHelper.Exists(filename);
        }

        public IEnumerable<string> GetFiles()
        {
            IEnumerable<string> filepaths = saveHelper.GetFiles();
            List<string> filenames = new List<string>();
            foreach (string filepath in filepaths)
            {
                filenames.Add(Path.GetFileName(filepath));
            }
            return filenames;
        }



      
        public string ReadText(string filename)
        {
            return saveHelper.ReadText(filename);
        }

       

        public void WriteTextAsync(string filename, string code, string age, string gender)
        {
            saveHelper.WriteTextAsync(filename, code,age,gender);
        }
    }
}
