using FileIODemo.CSVData;

namespace FileIODemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string deleteFile = @"D:\c#\Day27_FileIO\delete.txt";
            //DeleteFile(deleteFile);   //given path of any file will be deleted using DeleteFile() .
            //BinaryIODataOperations.BinaryDataSerialize();   //toConvert Object into BinaryFormat (Serialization using Binary).
            //BinaryIODataOperations.BinaryDeserialization();
            //JsonDataOperations.JsonSerialization();     //toConvert Object into Json Format (Serialization using Json);
            //JsonDataOperations.JsonDeserialization();
            //XMLDataOperations.XmlSerialization();
            //XMLDataOperations.XmlDeserialization();
            //string path = @"D:\c#\Day27_FileIO\New folder\csvDemo.csv";
            //List<Person> list = new List<Person>()
            //    {
            //        new Person(){PersonId = 1, Name = "Sachin", PhoneNumber = 98232233, Address = "bnglr", StartDate=DateTime.Now },
            //        new Person(){PersonId = 2, Name = "Ashwin", PhoneNumber = 98232233, Address = "krntk" , StartDate=DateTime.Now},
            //        new Person(){PersonId = 3, Name = "Dhoni", PhoneNumber = 98232233, Address = "delhi", StartDate=DateTime.Now },
            //        new Person(){PersonId = 4, Name = "Kumar", PhoneNumber = 98232233, Address = "mumbai" , StartDate=DateTime.Now}
            //    };
            //CsvDataOperations.CsvSerialize(list,path);
            //CsvDataOperations.CsvDeserialize(path);
            //CsvAndJsonDataOperations.ReadingFromCsvWritingToJson(); 
        }
        public static void DeleteFile(string path)
        {
            bool result=File.Exists(path);
            //bool result = IsFileExists(path);
            if(result)
            {
                File.Delete(path);
                Console.WriteLine("File has been Deleted Successfully .");
            }
            else
            {
                Console.WriteLine("File doesn't exists in the given path.");
            }
        }
        public static bool IsFileExists(string path)
        {
            bool result=File.Exists(path);
            if(result)
            {
                Console.WriteLine("File Exists.");
                return true;
            }
            else
            {
                Console.WriteLine("File Not Exists.");
                return false;
            }
        }
        public static void ReadAllLines()   //Read All the Lines from a File.
        {
            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";
            string[] lines;
            lines = File.ReadAllLines(path);

            Console.WriteLine("Total no.of lines are :" + lines.Length);
            Console.WriteLine("Line 0 : "+lines[0]);
            Console.WriteLine("Line 1 :"+lines[1]);
        }
        public static void ReadAllText()        //reads all text from a file
        {
            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";
            string text;
            text = File.ReadAllText(path);
            Console.WriteLine("Texts fetched from a given file are :"+text);
        }
        public static void CopyFile()   //copies file .
        {
            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";
            string copyPath = @"D:\c#\Day27_FileIO\FileIODemo\DemoFileNew.txt";
            File.Copy(path, copyPath);  //Copying file source path to Destination path.
        }
        public static void DeleteFile()
        {
            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFileNew.txt";
            File.Delete(path);      //method is used to delete an existing file .
        }
        public static void ReadFromStreamReader()  
        {   //stream reader is used to read data from a file using streams.The data from the file is first read into the stream.
            string path= @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt"; //Thereafter the application reads the data from the stream.
            using(StreamReader sr = new StreamReader(path))     
            {
                string s = "";
                while((s=sr.ReadLine())!=null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void WriteUsingStreamWriter()
        {   //The stream writer is used to write data ti a file using streams.The data from the application is first written into the stream.
            string path= @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";//After that the stream writes the data to the file .
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine("Hello world -  .Net is awesome");
                sr.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
    }
}