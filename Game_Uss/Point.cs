using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Point
    {
        public int x;
        public int y; 
        public char sym;

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y; 
            sym = _sym;
        }
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = p.sym;
        }
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.Left)
            { 

                x -= offset;
            }
            else if (direction == Direction.Right)
            {
                x += offset;
            }
            else if (direction == Direction.up)
            {
                y -= offset;
            }
            else if(direction== Direction.down)
            {
                y += offset;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        //public override string ToString()
        //{
        //    return x + "," + y + "," + sym;
        //}
    }
}
