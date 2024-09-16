using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game_Uss
{
    public class Levels
    {
        public static int CurrentLevel = 1;
        public static int Speed = 100;
        public static int Counter(int count)
        {
            count++;
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Очки: {count}");

            
            if (count % 5 == 0)
            {
                LevelUp();
    
            }

            return count;
        }
        public static void LevelUp()
        {
            if (CurrentLevel < 3)
            {
                CurrentLevel++;
                Speed -= 25;
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Level: {CurrentLevel}");
                Console.ForegroundColor = ConsoleColor.White;
                ChangeLevelColor(CurrentLevel);

            }
        }
        public static void ChangeLevelColor(int level)
        {
            switch (level)
            {
                case 1:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Cyan; 
                    Console.ForegroundColor = ConsoleColor.White;  
                      
                    break;
                case 2:                     
                    Console.ForegroundColor = ConsoleColor.Green;                    
                    break;
                case 3:
                      
                    Console.ForegroundColor = ConsoleColor.Red;         
                    break;
                default:
                    Console.ResetColor();  
                    break;

            }
        }
        public static void GameOver()
        {
            if (CurrentLevel == 3)
            {
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("sa võitsid");
                Console.SetCursorPosition(30, 11);
                Console.WriteLine($"teie punktid: {CurrentLevel}");
            }
            else
            {
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("sa suri");
                Console.SetCursorPosition(30, 11);
                Console.WriteLine($"teie punktid: {CurrentLevel}");
            }
        }     
    }
}


