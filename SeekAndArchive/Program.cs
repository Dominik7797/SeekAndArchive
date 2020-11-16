using System;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFiles getFiles = new GetFiles();
            getFiles.GetFilesBySearch();

            Console.WriteLine("For new search press n, to save press s, to reload prev save press r, to exit press e");
            var option = Console.ReadLine();

            while (option != "e")
            {
                if (option == "n")
                {
                    getFiles.GetFilesBySearch();
                }

                if (option == "s")
                {
                    //todo get path without full path.
                    getFiles.SerializeObjectToTxt(@"C:\Users\dommi\source\repos\SeekAndArchive\SeekAndArchive\data.txt");
                }

                if (option == "r")
                {
                     var prevSearch = getFiles.DeserializeFromTxtToObject(@"C:\Users\dommi\source\repos\SeekAndArchive\SeekAndArchive\data.txt");
                    foreach(var prevFile in prevSearch)
                    {
                        Console.WriteLine(prevFile);
                    }
                }

                Console.WriteLine("For new search press n, to save press s, to reload prev save press r, to exit press e");
                option = Console.ReadLine();
            }
        }
    }
}
