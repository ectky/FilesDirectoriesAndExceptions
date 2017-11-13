using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            List<Student> students = new List<Student>();
            for (int i = 1; i < n +1; i++)
            {
                string[] line = input[i].Split(' ').ToArray();
                Student s = new Student();
                s.Name = line[0];
                s.Grades = line.Skip(1).Select(double.Parse).ToList();
                students.Add(s);
            }
            File.WriteAllText("output.txt", "");
            students.Where(s => s.Average >= 5.00).OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average).ToList()
                .ForEach(s => File.
                AppendAllText("output.txt" ,$"{s.Name} -> {s.Average:F2}{Environment.NewLine}"));
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average => Grades.Average();
    }
}
