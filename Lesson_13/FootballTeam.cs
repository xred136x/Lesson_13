using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13
{
    internal class FootballTeam
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Ranking { get; set; }
        public List<Player> Players { get;}

        public FootballTeam(string name, string country, int ranking, List<Player> players)
        {
            Name = name;
            Country = country;
            Ranking = ranking;
            Players = players;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Console.WriteLine("Игрок " + player + " добавлен.");
        }

        public void RemovePlayer(string namePlayer)
        {
            foreach (var player in Players)
            {
                if (player.Name.Equals(namePlayer))
                {
                    Players.Remove(player);
                    Console.WriteLine("Игрок " + namePlayer + " удалён.");
                    break;
                }
            }
        }

        public List<Player> GetPlayerByPosition(string position)
        {
            List<Player> listPlayersByPosition = new List<Player>();
            foreach (var player in Players)
            {
                if (player.Position.Equals(position))
                {
                    listPlayersByPosition.Add(player);
                }
            }

            return listPlayersByPosition;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        private string PlayersToString()
        {
            string players = "";
            for(int i = 0; i < Players.Count; i++)
            {
                players += Players[i].ToString() + '\n';
            }

            return players;
        }
        public override string ToString()
        {
            return "Название команды: " + Name + "\nСтрана: " + Country + "\nРейтинг команды: " + Ranking + 
                "\nИгроки: \n" + this.PlayersToString();
        }

    }
}
