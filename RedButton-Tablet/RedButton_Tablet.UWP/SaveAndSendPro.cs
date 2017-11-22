using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void WriteText(string filename, string text)
        {
            throw new NotImplementedException("Writing files is not implemented");
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

        public void WriteText(string filename, string code, string age, string gender)
        {
            throw new NotImplementedException();
        }

        public string ReadText(string filename, string code, string age, string gender)
        {
            throw new NotImplementedException();
        }
    }
}
