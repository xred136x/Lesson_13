using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    internal class DataStorage<T>
    {
        public List<T> Data { get; set; }

        public void AddData(T data)
        {
            Data.Add(data);
        }

        public void Remove(T data)
        {
            foreach (var d in Data)
            {
                if (d.Equals(data))
                {
                    Data.Remove(d);
                    Console.WriteLine("Данные " + d.ToString() + " удалены.");
                    break;
                }
            }

        }

        public bool ContainsData(T data)
        {
            foreach (var d in Data)
            {
                if (d.Equals(data))
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintData()
        {
            Console.WriteLine(Data.ToArray().ToString());
        }

    }
}
