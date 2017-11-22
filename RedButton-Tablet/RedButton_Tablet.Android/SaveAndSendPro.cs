using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(RedButton_Tablet.Droid.SaveAndSendPro))]

namespace RedButton_Tablet.Droid
{
    class SaveAndSendPro : ISaveAndSendPro
    {
        public bool Exists(string filename)
        {
            string filepath = GetFilePath(filename);
            return File.Exists(filepath);
        }

        public void WriteText(string filename, string code,string age,string gender)
        {
            string filepath = GetFilePath(filename);

           
            File.WriteAllText(filepath, ("ProQA code is: "+code));
               using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine();
                sw.WriteLine("Age is: {0}",age );
                sw.WriteLine("Gender is: {0}",gender);
               
            }
        }

        public string ReadText(string filename)
        {
            string filepath = GetFilePath(filename);
            return File.ReadAllText(filepath);
        }

        public IEnumerable<string> GetFiles()
        {
            return Directory.GetFiles(GetDocsPath());
        }

        public void Delete(string filename)
        {
            File.Delete(GetFilePath(filename));
        }

        // Private methods.
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }

        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

       
    }
    }
