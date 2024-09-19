using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game_Uss
{
    using System;
    using System.Collections.Generic;

    namespace Game_Uss
    {
        public class Barriers : Snake
        {
            public Barriers(Point tail, int length, Direction _direction) : base(tail, length, _direction)
            {
                currentColor = ConsoleColor.Green;
            }

            public void AutoMove(int height)
            {
                // Препятствия всегда будут двигаться вниз.
                direction = Direction.Down;
                Move();
                Draw();
                Teleportation(height);
            }

            public new void Draw()
            {
                Console.ForegroundColor = currentColor;
                base.Draw();
            }

            public void Teleportation(int height)
            {
                Point head = pList.Last();

                if (head.y >= height)
                {
                    head.y = 0; 
                }
            }
            public void Clear()
            {
                foreach (var point in pList)
                {
                    point.Clear();  
                }
                pList.Clear();  
            }
        }
    }
}
