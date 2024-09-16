using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Game_Uss
{
    public class Registr
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Registr(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public void UpdateScore(int newScore)
        {
            Score = newScore;
        }

        public static void RegisterUser(List<Registr> userScores, string name)
        {
           
            while (true)
            {  
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Имя не может быть пустым. Попробуйте снова.");
                    continue;
                }
                break;
            }
 
            int score = 0;
            Registr userScore = new Registr(name, score);
            userScores.Add(userScore);

            //Console.WriteLine("Mängijat:");
            //foreach (var user in userScores)
            //{
            //    Console.WriteLine($"nimi {userScore.Name}, punktid {userScore.Score}");
            //}
        }
        public static void Players(List<Registr> userScores)
        {
            Console.WriteLine("Mängijat:");
            foreach (var user in userScores)
            {
                Console.WriteLine($"nimi {user.Name}, punktid {user.Score}");
            }
        }
    }
}
