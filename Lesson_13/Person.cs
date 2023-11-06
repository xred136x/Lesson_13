using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return "Имя: " + Name + ", возраст: " + Age;
        }
    }
}
