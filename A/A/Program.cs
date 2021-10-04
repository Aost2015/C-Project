using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExportToTextFile
{
    class teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string course { get; set; }
        public string section { get; set; }
    

    }

   

    static class Program
    {

        static void Main(string[] args)
        {
           teacher[] data = new teacher[] {
            new teacher() { ID = 1, Name = "Aishah", course = "c# programming" ,section="IT"},
            new teacher() { ID = 2, Name = "Huda", course = "Poetry" , section="English Literature"},

             
        };

            

            Console.WriteLine("***********Wellcome to RainBow School***********");
            Console.WriteLine("You can cheose: 1-To add teacher data , 2-update , 3-disply data");
            int selection = Convert.ToInt32(Console.ReadLine());
            
          
            switch (selection)
            {

                case 1:
                   
                    Console.WriteLine("Add Id");
                    string AddID =Console.ReadLine();
                    Console.WriteLine("Add Name");
                    string AddName = Console.ReadLine();
                    Console.WriteLine("Add course");
                    string Addcourse = Console.ReadLine();
                    Console.WriteLine("Add section");
                    string Addsection = Console.ReadLine();
                   
                    var Tdata = new [] { AddID, AddName, Addcourse, Addsection };
                    foreach (string v in Tdata)
                    {  

                        File.AppendAllText("RainBowSchool.txt", (";" + v));

                    }
                    File.AppendAllText("RainBowSchool.txt", " \n");
                    Console.ReadKey();


                    break;

                case 2:
                    Console.WriteLine("Enter Your ID to update Data ");
                    string UpdateID = Console.ReadLine();
                    var oldLines = System.IO.File.ReadAllLines("RainBowSchool.txt");
                    var newLines = oldLines.Where(line => !line.Contains(UpdateID));
                    System.IO.File.WriteAllLines("RainBowSchool.txt", newLines);
                    Console.WriteLine("DONE now you can select 1 to add new data ");
                    Console.ReadKey();

                    break;

                case 3:
                    string[] lines = System.IO.File.ReadAllLines("RainBowSchool.txt");
                    System.Console.WriteLine("************Rainbow School System***********");
                    foreach (string line in lines)
                    {
                        
                        Console.WriteLine("\t" + line);
                    }
                  
                    Console.ReadKey();

                    break;
                default:
                    Console.WriteLine("Rong option");
                    Console.ReadKey();
                    break;

            }

           
        }

        static void DataInTxt<T>(this IEnumerable<T> data, string FileName, char y)
        {
            using (var x = File.CreateText(FileName))
            {
                var plist = typeof(T).GetProperties().ToList();
                if (plist.Count > 0)
                {
                    var seperte = y.ToString();
                    x.WriteLine(string.Join(seperte, plist.Select(p => p.Name)));
                    foreach (var item in data)
                    {
                        var values = new List<object>();
                        foreach (var p in plist) values.Add(p.GetValue(item));
                        x.WriteLine(string.Join(seperte, values));

                        Console.WriteLine(string.Join(seperte, values));
                    }
                }
            }
        }
    }

    
}