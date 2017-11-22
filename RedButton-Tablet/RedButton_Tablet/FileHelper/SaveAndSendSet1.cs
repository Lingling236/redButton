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
        public async Task Save_Value<T>(String Key, T ValueToSave)
        {
            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, ValueToSave);
            }

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Cache",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(Key + ".txt",
                CreationCollisionOption.ReplaceExisting);

            await file.WriteAllTextAsync(doc.ToString());
        }
        /// <summary>
        /// Reading Values from the Storage...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <returns></returns>
        public async Task<T> Get_Value<T>(String Key)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Cache",
                CreationCollisionOption.OpenIfExists);

            ExistenceCheckResult isFileExisting = await folder.CheckExistsAsync(Key + ".txt");

            if (!isFileExisting.ToString().Equals("NotFound"))
            {
                try
                {
                    IFile file = await folder.CreateFileAsync(Key + ".txt",
                    CreationCollisionOption.OpenIfExists);

                    String languageString = await file.ReadAllTextAsync();

                    XmlSerializer oXmlSerializer = new XmlSerializer(typeof(T));
                    return (T)oXmlSerializer.Deserialize(new StringReader(languageString));
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Delete any value from the Storage...
        /// </summary>
        /// <param name="Key"></param>
        public async void Delete_Value(String Key)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Cache",
                CreationCollisionOption.OpenIfExists);

            ExistenceCheckResult isFileExisting = await folder.CheckExistsAsync(Key + ".txt");

            if (!isFileExisting.ToString().Equals("NotFound"))
            {
                try
                {
                    IFile file = await folder.CreateFileAsync(Key + ".txt",
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
            IEnumerable<IFile> filepath =await rootFolder.GetFilesAsync();
            List<string> filenames = new List<string>();
            foreach (var fp in filepath)
            {
              
                filenames.Add(fp.ToString());


            }
            return filenames;

        }
    }
}

