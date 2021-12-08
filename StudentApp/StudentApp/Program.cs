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
                    string[] ar = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
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

            // Get the eldest student in studentList
            var eldestStudent = studentList.OrderByDescending(item => item.Age).First();

            Console.WriteLine(" \r\nEldest Student:");
            Console.WriteLine(String.Join(",", eldestStudent.Name, eldestStudent.Address, eldestStudent.Age, eldestStudent.Hobby));
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
