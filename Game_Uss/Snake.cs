using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Snake:Figure
    {
        Direction direction;
        public Snake(Point tail, int lenght, Direction _direction )
        { 
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                direction = _direction;
                Point p = new Point(tail);
                p.Move(i,direction);
                pList.Add(p);
            }
        }
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction); 
            return nextPoint;
        }
    }
}
