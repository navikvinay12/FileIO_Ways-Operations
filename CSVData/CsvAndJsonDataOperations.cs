using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo.CSVData
{
    public class CsvAndJsonDataOperations
    {
        public static void ReadingFromCsvWritingToJson()//Reading from Csv - Csv Deserialization & Writing to Json - Json Serialization
        {
            string csvPath = @"D:\c#\Day27_FileIO\New folder\csvDemo.csv";
            string jsonPath = @"D:\c#\Day27_FileIO\New folder\readingFromCsvAndWritingToJson.json";
            List<Person> list = CsvDataOperations.CsvDeserialize(csvPath);
            JsonDataOperations.JsonSerialization(jsonPath, list);
        }
        public static void ReadingFromJsonWritingToCsv()//Reading from Json-Json Deserialization & Writing to Csv-Csv Serialization.
        {
            try
            {
                string csvPath = @"D:\c#\Day27_FileIO\New folder\readingFromJsonAndWritingIntoCsv.csv";
                string jsonPath = @"D:\c#\Day27_FileIO\New folder\readingFromCsvAndWritingIntoJson.json";
                List<Person> list = JsonDataOperations.JsonDeserialization(jsonPath);
                CsvDataOperations.CsvSerialize(list, csvPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
