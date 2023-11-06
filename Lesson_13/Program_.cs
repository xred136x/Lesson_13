using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> Grades { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Чтение JSON из файла
        string json = System.IO.File.ReadAllText("C:\\Users\\С - Преподаватель\\Documents\\Ушаков\\ConsoleApp1\\input.json");

        // Десериализация JSON в список объектов Student
        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);

        // Вычисление среднего балла и вывод информации о студентах
        foreach (var student in students)
        {
            double averageGrade = CalculateAverageGrade(student.Grades);

            Console.WriteLine("Имя: " + student.Name);
            Console.WriteLine("Возраст: " + student.Age);
            Console.WriteLine("Средний балл: " + averageGrade);
            Console.WriteLine();
        }

        // Сериализация списка студентов в JSON
        string outputJson = JsonConvert.SerializeObject(students);

        // Сохранение JSON в файл
        System.IO.File.WriteAllText("output.json", outputJson);
    }

    static double CalculateAverageGrade(List<int> grades)
    {
        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }

        return sum / grades.Count;
    }
}