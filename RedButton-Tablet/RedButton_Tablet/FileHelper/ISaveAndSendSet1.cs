using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedButton_Tablet
{
    public interface ISaveAndSendSet1
    {
        bool Exists(string filename);
        void WriteText(string filename, Set1 set1);
        Set1 ReadText(string filename);
        IEnumerable<Set1> GetFiles();
        void Delete(string filename);
    }
}
