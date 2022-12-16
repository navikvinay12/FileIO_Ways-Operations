using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileIODemo
{
    public class XMLDataOperations
    {
        public static string path = @"D:\c#\Day27_FileIO\FileIODemo\xmlData.xml";
        public static void XmlSerialization()
        {
            StreamWriter sw = null ;
            try
            {
                List<Person> list = new List<Person>()
                {
                    new Person(){PersonId = 1, Name = "Sachin", PhoneNumber = 98232233, Address = "bnglr" },
                    new Person(){PersonId = 2, Name = "Ashwin", PhoneNumber = 98232233, Address = "krntk" },
                    new Person(){PersonId = 3, Name = "Dhoni", PhoneNumber = 98232233, Address = "delhi" },
                    new Person(){PersonId = 4, Name = "Kumar", PhoneNumber = 98232233, Address = "mumbai" }
                };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                sw = new StreamWriter(path);
                xmlSerializer.Serialize(sw, list);
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
        public static void XmlDeserialization()
        {
            StreamReader sr = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                sr = new StreamReader(path);
                List<Person> listOfPerson = (List<Person>)xmlSerializer.Deserialize(sr);
                foreach (Person person in listOfPerson)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }
    }
}
