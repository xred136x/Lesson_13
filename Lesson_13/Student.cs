using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get;}

        public Student(string name, int age, List<int> grades)
        {
            Name = name;
            Age = age;
            Grades = grades;
        }

        public override string ToString()
        {
            return Name + " " + Age + Grades.ToArray().ToString();
        }
    }
}
