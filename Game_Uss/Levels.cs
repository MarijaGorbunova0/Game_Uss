using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
        public static void ChangeLevelColor(int level)
        {
            switch (level)
            {
                case 1:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Cyan;  // Стандартный цвет
                    Console.ForegroundColor = ConsoleColor.White;  // Стандартный цвет текста
                      // Применяем новый цвет фона
                    break;
                case 2:
                     
                    Console.ForegroundColor = ConsoleColor.Red;    // Желтый текст
                    Console.Clear();  // Очищаем консоль для применения изменений
                    break;
                case 3:
                      
                    Console.ForegroundColor = ConsoleColor.Red;        // Красный текст
                    Console.Clear();  // Очищаем консоль
                    break;
                default:
                    Console.ResetColor();  // Возвращаем стандартный цвет по умолчанию
                    break;

            }
        }
    }
}


