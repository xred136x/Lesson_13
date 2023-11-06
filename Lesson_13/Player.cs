﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    internal class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public Player(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }

        public override string ToString()
        {
            return "Имя: " + Name + "; Возраст: " + Age + "; Позиция игрока: " + Position;
        }
    }
}
