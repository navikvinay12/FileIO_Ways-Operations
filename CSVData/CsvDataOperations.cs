using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using FileIODemo;

namespace FileIODemo.CSVData
{
    public class CsvDataOperations
    {
        //public static string path = @"D:\c#\Day27_FileIO\New folder\csvDemo.csv";
        public static void CsvSerialize(List<Person> list,string path)
        {
            StreamWriter sw = null;
            try
            {
                CultureInfo cul =new CultureInfo("en-us");
                sw = new StreamWriter(path);
                Console.WriteLine($"Before culture : {CultureInfo.CurrentCulture.Name}");
                var csvwriter = new CsvWriter(sw, cul);
                //Console.WriteLine($"After Culture: {CultureInfo.CurrentCulture.Name}");
                csvwriter.WriteRecords(list);
                sw.Flush();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }
        public static List<Person> CsvDeserialize(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    //CultureInfo cul = new CultureInfo("en-us");
                    //CsvReader csvreader=new CsvReader(sr,cul);
                    CsvReader csvreader=new CsvReader(sr,CultureInfo.InvariantCulture);
                    var listOfPerson = csvreader.GetRecords<Person>().ToList();
                    foreach(Person person in listOfPerson)
                    {
                        Console.WriteLine(person);
                    }
                    return listOfPerson;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
