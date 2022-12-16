using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo
{
    public class BinaryIODataOperations
    {
        //COnverting object into binary data
        public static void BinaryDataSerialize()
        {
            try
            {

            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Sachin", Phone = 98232233, Address = "bnglr" },
                new Employee(){Id = 2, Name = "Rajeev", Phone = 98232233, Address = "krntk" },
                new Employee(){Id = 3, Name = "Donald", Phone = 98232233, Address = "delhi" },
                new Employee(){Id = 4, Name = "Robert", Phone = 98232233, Address = "mumbai" }
            };
            BinaryFormatter binaryFormatter= new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.OpenOrCreate);//FileMode.Open =if it is there it will open and else it will first create and than open 
            binaryFormatter.Serialize(stream, employeeList);    //it requires parameter as stream and object .

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void BinaryDeserialization()
        {
            string path = @"D:\c#\Day27_FileIO\FileIODemo\DemoFile.txt";
            BinaryFormatter binaryFormatter =new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            List<Employee> res=(List<Employee>)binaryFormatter.Deserialize(fileStream); //returning back to its original object form. 
            foreach(Employee emp in res)
            {
                Console.WriteLine(emp);
            }
        }
    }
    [Serializable] //In the binary data format if u want to convert any object we have to use an attribute in the top/permission.
    public class Employee
    {
        public int Id { get; set; }
        public int Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return $"ID:{Id}  Phone:{Phone}  Name:{Name}  Address:{Address}";
        }
    }
}
//Binary Serialization:Converting an Object to a Binary format (Note-here binary format is mixed code so dont think only 0,1)-
//which is not in a human readable format is called Binary Serialization.Deserialization - Converting back the binary to human readable format .
