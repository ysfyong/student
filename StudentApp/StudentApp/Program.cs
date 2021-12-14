using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StudentApp
{
    class Program
    {
        static readonly string textFile = @"Student.txt";
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            if (File.Exists(textFile))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(textFile);

                // Skip the header
                lines = lines.Skip(1).ToArray();

                foreach (string line in lines)
                {
                    // Split by comma outside double quotes
                    //string[] ar = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    string[] ar = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)(?![^[]*])");

                    studentList.Add(new Student {
                        Name    = ar[0].ToString(),
                        Address = ar[1].ToString(),
                        Age     = int.Parse(ar[2]),
                        Hobby   = ar[3].ToString()
                    });
                }
            }

            Console.WriteLine("List of Students:");
            foreach (Student s in studentList)
            {
                Console.WriteLine(String.Join(",", s.Name, s.Address, s.Age, s.Hobby));
            }

            // Get Max Age
            var maxAge = studentList.Max(x => x.Age);

            Console.WriteLine("\r\nMax age:" + maxAge + "\r\n");

            foreach (Student s in studentList)
            {
                if(s.Age == maxAge)
                Console.WriteLine(String.Join(",", s.Name, s.Address, s.Age, s.Hobby));
            }

            Console.ReadKey();
        }

        public class Student
        {
            public string Name;
            public string Address;
            public int    Age;
            public string Hobby;
        }
    }
}
