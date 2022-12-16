using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileIODemo
{
    public class JsonDataOperations
    {
        public static string path = @"D:\c#\Day27_FileIO\FileIODemo\JsonDataPostSerialization.json";
        public static void JsonSerialization(string path, List<Person> list)
        {
            try
            {
                //List<Person> list = new List<Person>()
                //{
                //    new Person(){PersonId = 1, Name = "Sachin", PhoneNumber = 98232233, Address = "bnglr" },
                //    new Person(){PersonId = 2, Name = "Ashwin", PhoneNumber = 98232233, Address = "krntk" },
                //    new Person(){PersonId = 3, Name = "Dhoni", PhoneNumber = 98232233, Address = "delhi" },
                //    new Person(){PersonId = 4, Name = "Kumar", PhoneNumber = 98232233, Address = "mumbai" }
                //};
                string jsonData = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, jsonData);//whatever path which we hv passed even if the file name is unavailable it will create a new one and store the jsonData.
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<Person> JsonDeserialization(string path)
        {
            try
            {
                if(File.Exists(path))
                {
                    string result = File.ReadAllText(path);
                    List<Person> listOfPerson = JsonConvert.DeserializeObject<List<Person>>(result);
                    foreach (Person person in listOfPerson)
                    {
                        Console.WriteLine(person);
                    }
                    return listOfPerson;
                }
                else
                {
                    Console.WriteLine("File Not Exists! ");
                    return default;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public override string ToString()
        {
            return $"ID:{PersonId}  Phone:{PhoneNumber}  Name:{Name}  Address:{Address}  Date:{StartDate}";
        }
    }
}
