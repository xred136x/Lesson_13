using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStorage<Person> personStorage = new DataStorage<Person>();

            personStorage.AddData(new Person("Даниил Зуев", 23));
            personStorage.AddData(new Person("Семён Морозов", 24));
            personStorage.AddData(new Person("Вячеслав Дёмин", 25));
            personStorage.AddData(new Person("Кирил Фурман", 26));
            personStorage.AddData(new Person("Илья Захаров", 21));

            personStorage.PrintData();

        }

        public static void Task_3()
        {
            /*
            Требуется разработать консольное приложение, которое выполняет операции с данными о футбольных командах.

            Создайте класс "FootballTeam" со следующими свойствами:

            "Name" - имя команды (строка);
            "Country" - страна команды (строка);
            "Ranking" - рейтинг команды (целое число);
            "Players" - массив объектов "Player" (см. ниже).
            Создайте класс "Player" со следующими свойствами:

            "Name" - имя игрока (строка);
            "Age" - возраст игрока (целое число);
            "Position" - позиция игрока (строка).
            Разработайте методы класса "FootballTeam":

            "AddPlayer" - принимает объект "Player" и добавляет его в массив "Players";
            "RemovePlayer" - принимает имя игрока и удаляет его из массива "Players";
            "GetPlayersByPosition" - принимает позицию игрока и возвращает массив игроков с заданной позицией;
            "ToJson" - возвращает JSON-представление объекта "FootballTeam".
            Напишите консольное приложение с использованием вышеописанных классов, которое выполняет следующие действия:

            Создает объект "FootballTeam";
            Добавляет несколько игроков в команду;
            Удаляет одного игрока из команды;
            Получает массив игроков определенной позиции и выводит их на экран;
            Преобразует объект "FootballTeam" в JSON и выводит его на экран.
            */
            FootballTeam footballTeam = new FootballTeam("Амкар", "Россия", 10, new List<Player> {
           new Player("Лео Месси", 27, "правый нападающий"),
           new Player("Диего Марадонна", 25, "центральный нападающий"),
           new Player("Семён Морозов", 24, "центральный защитник"),
           new Player("Антон Бочаров", 23, "правый защитник"),
           new Player("Максим Игнатьев", 23, "левый защитник")
           });

            footballTeam.AddPlayer(new Player("Лев Яшин", 25, "вратарь"));
            footballTeam.AddPlayer(new Player("Олег Мостовой", 26, "центральный нападающий"));
            Console.WriteLine(footballTeam.ToString());
            Console.WriteLine();
            footballTeam.RemovePlayer("Максим Игнатьев");
            footballTeam.RemovePlayer("Антон Бочаров");
            Console.WriteLine(footballTeam.ToString());
            Console.WriteLine();
            foreach (Player player in footballTeam.GetPlayerByPosition("центральный нападающий"))
            {
                Console.WriteLine(player);
            }

            string json = footballTeam.ToJson();

            Console.WriteLine(json);
        }

        public static void Task_2()
        {
            /*
             Задание:
            Вам необходимо создать простую консольную программу на C#, которая работает с JSON файлами. Программа должна выполнять следующие шаги:

            Программа должна читать JSON файл "input.json", содержащий информацию о студентах. Файл должен иметь следующую структуру:
            [
              {
                "Name": "John",
                "Age": 20,
                "Grades": [ 90, 85, 92 ]
              },
              {
                "Name": "Jane",
                "Age": 22,
                "Grades": [ 95, 88, 78 ]
              }
            ]

            С помощью библиотеки Newtonsoft.Json (Newtonsoft.Json), программа должна сериализовать содержимое файла в список объектов типа "Student". Создайте соответствующий класс "Student" с необходимыми свойствами (name, age, grades).

            Программа должна вычислить средний балл каждого студента и вывести информацию о студентах в следующем формате:

            Имя: Иван
            Возраст: 20
            Средний балл: 85.3

            Имя: Мария
            Возраст: 19
            Средний балл: 91.3

            Всю полученную информацию о студентах необходимо сериализовать обратно в JSON формат и сохранить в файл "output.json".
            Пожалуйста, обратите внимание на использование библиотеки Newtonsoft.Json для работы с JSON.
             */
            List<Student> students = new List<Student>();
            string json;
            using (StreamReader reader = new StreamReader("C:\\Users\\С - 3\\Documents\\Гоголин\\Lesson_13\\Lesson_13\\data.json"))
            {
                json = reader.ReadToEnd();
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("Имя: " + students[i].Name);
                Console.WriteLine("Возраст: " + students[i].Age);
                double avg = 0;
                int summ = 0;
                for (int j = 0; j < students[i].Grades.Count; j++)
                {
                    summ += students[i].Grades[j];
                }
                avg = (double)summ / students.Count;
                Console.WriteLine("Средний балл: " + avg);
            }

            string output_json = JsonConvert.SerializeObject(students);

            using (FileStream fstream = new FileStream("C:\\Users\\С - 3\\Documents\\Гоголин\\Lesson_13\\Lesson_13\\output.json", FileMode.Append, FileAccess.Write))
            {
                byte[] writeText = Encoding.Unicode.GetBytes(output_json);
                fstream.Write(writeText, 0, writeText.Length);
            }
        }


        public static void Task_1()
        {
            Randomizer rnd = new Randomizer(11);
            int[] arr = new int[20];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 10);
                Console.WriteLine(arr[i] + " ");
            }
        }

    }

    

}



public class Randomizer
{
    private const int Multiplier = 1103515245;
    private const int Increment = 12345;
    private const int Modulus = 2147483647;

    private int seed;

    public Randomizer(int seed)
    {
        this.seed = seed;
    }

    public int Next(int min, int max)
    {
        seed = Math.Abs((Multiplier * seed + Increment) % Modulus);
        return seed % (max - min + 1) + min ;
    }
}
