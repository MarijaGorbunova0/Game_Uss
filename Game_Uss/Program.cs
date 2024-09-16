using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            
            //Point p1 = new Point(1, 3, '*');
            //p1.Draw();
            //Point p2 = new Point(4, 5, '#');
            //p2.Draw();

            // List<int> numList = new List<int>();
            // numList.Add(0);
            // numList.Add(1);
            // numList.Add(2);

            //int x = numList[0];

            //foreach (int i in numList)
            //{
            //   Console.WriteLine(i);
            // }

            int bal = 0; 
            Point p = new Point(4, 5, '*');

            Snake snake = new Snake(p, 4, Direction.Down);
            
            Food createFood = new Food(80, 25, '$');
            Point food = createFood.CreateFood();

            Menu.PrintMenu();
            List<Registr> userScores = new List<Registr>();
            Registr.Players(userScores);
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("kirutage oma nimi");
            Console.SetCursorPosition(30, 16);
            string name = Console.ReadLine();
            if (userScores.Exists(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("te olite v spiske");

            }
            else
            {
                Registr.RegisterUser(userScores, name);
                Console.Clear();
            }

          
            walls.Draw();
            food.Draw();
            snake.Draw();
            while (true)
            {
                Console.SetCursorPosition(30, 0);
                Console.WriteLine($"punktid: {bal}");
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = createFood.CreateFood();
                    food.Draw();
                    bal = Levels.Counter(bal);
                
                }
                else if(bal < 1)
                {  
                    snake.Move();
                }
                else
                {

                    Levels.GameOver();
                }
                Thread.Sleep(Levels.Speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
               
            }
            // pList.Add(p1);
            // pList.Add(p2);
        }
    }
}
