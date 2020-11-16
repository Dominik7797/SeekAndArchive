using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class GetFiles
    {
        List<string> searchResult = new List<string>();

        public void GetFilesBySearch()
        {
            Console.WriteLine("Give a filename eg:Text.rtf");
            var filename = Console.ReadLine();
            Console.WriteLine(@"Give a directory to look in. eg: C:\Testing\");
            var directory = Console.ReadLine();
            var counter = 0;

            try
            {
                 var allFiles = Directory.GetFiles(directory, filename, SearchOption.AllDirectories);
                foreach (var file in allFiles)
                {
                    counter++;
                    Console.WriteLine(file);
                    searchResult.Add(file);
                }

            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Files found:" + counter);
            }
        }

        public void SerializeObjectToTxt(String path)
        {

            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(file, searchResult);
                Console.WriteLine("Saved.");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        public List<string> DeserializeFromTxtToObject(String path)
        {

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and
                // assign the reference to the local variable.
                var prevSearch = (List<string>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return searchResult;

        }
    }
}
