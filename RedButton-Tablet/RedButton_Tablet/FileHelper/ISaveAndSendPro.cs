using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedButton_Tablet
{
    public interface ISaveAndSendPro
    {
       bool Exists(string filename);
        void WriteText(string filename, string code,string age,string gender);
        string ReadText(string filename);
        IEnumerable<string> GetFiles();
        void Delete(string filename);
    }
}
