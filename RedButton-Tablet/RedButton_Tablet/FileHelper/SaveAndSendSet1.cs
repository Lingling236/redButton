using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RedButton_Tablet.FileHelper
{
  class SaveAndSendSet1
    {
        
        /// <summary>
        /// Saving Values to the Storage...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="ValueToSave"></param>
        /// <returns></returns>
        public async Task Save_Value(String filename, Set1 set1)
        {
            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                var serializer = new XmlSerializer(typeof(Set1));
                serializer.Serialize(writer, set1);
            }
            //get the folder name and path 
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            // create a new subfolder in the local folder 
            IFolder folder = await rootFolder.CreateFolderAsync("Set1",
                CreationCollisionOption.OpenIfExists);
            //create a file 
            IFile file = await folder.CreateFileAsync(filename,
                CreationCollisionOption.ReplaceExisting);

            await file.WriteAllTextAsync(doc.ToString());
        }
        /// <summary>
        /// Reading Values from the Storage...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <returns></returns>
        public async Task<Set1> Get_Value<T>(String filename)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Set1",
                CreationCollisionOption.OpenIfExists);

            ExistenceCheckResult isFileExisting = await folder.CheckExistsAsync(filename);

            if (!isFileExisting.ToString().Equals("NotFound"))
            {
                try
                {
                    IFile file = await folder.CreateFileAsync(filename,
                    CreationCollisionOption.OpenIfExists);

                    String languageString = await file.ReadAllTextAsync();

                    XmlSerializer oXmlSerializer = new XmlSerializer(typeof(T));
                    return (Set1)oXmlSerializer.Deserialize(new StringReader(languageString));
                }
                catch (Exception ex)
                {
                   var message= ex.Message;
                    return default(Set1);
                }
            }

            return default(Set1);
        }

        /// <summary>
        /// Delete any value from the Storage...
        /// </summary>
        /// <param name="Key"></param>
        public async void Delete_Value(String filename)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Set1",
                CreationCollisionOption.OpenIfExists);

            ExistenceCheckResult isFileExisting = await folder.CheckExistsAsync(filename + ".txt");

            if (!isFileExisting.ToString().Equals("NotFound"))
            {
                try
                {
                    IFile file = await folder.CreateFileAsync(filename + ".txt",
                    CreationCollisionOption.OpenIfExists);

                    await file.DeleteAsync();
                }
                catch (Exception ex)
                {
                 
                }
            }
        }
        public async Task<IEnumerable<string>> GetFilesAsync() {

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Set1",
               CreationCollisionOption.OpenIfExists);

            IEnumerable<IFile> filepath =await folder.GetFilesAsync();
            List<string> filenames = new List<string>();
            foreach (var fp in filepath)
            {
              
              filenames.Add(fp.Name);


            }
            return filenames;

        }
    }
}

