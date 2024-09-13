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
            

            //Point p1 = new Point(1, 3, '*');
            //p1.Draw();
            //Point p2 = new Point(4, 5, '#');
            //p2.Draw();

            HLines UPline = new HLines(0, 78, 0, '+');
            HLines DownLine = new HLines(0, 78, 24, '+');
            UPline.Drow();
            DownLine.Drow();
            VLines leftLine = new VLines(0, 24, 0, '+');
            VLines rightLine = new VLines(0, 24, 78, '+');
            leftLine.Drow();
            rightLine.Drow();
            // List<int> numList = new List<int>();
            // numList.Add(0);
            // numList.Add(1);
            // numList.Add(2);

            //int x = numList[0];

            //foreach (int i in numList)
            //{
            //   Console.WriteLine(i);
            // }


            Point p = new Point(4, 5, '*');

            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Drow();
            Food createFood = new Food(80, 25, '$');
            Point food = createFood.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = createFood.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
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
