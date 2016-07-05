using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_Ride_The_Horse
{
    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Point> GetNeighbours(Func<Point, bool> IsNeighbourFunc)
        {
            List<Point> neighbours = new List<Point>();
            var neighbour = new Point(X - 1, Y - 2);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X - 2, Y - 1);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X - 2, Y + 1);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X - 1, Y + 2);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X + 1, Y + 2);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X + 2, Y + 1);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X + 2, Y - 1);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            neighbour = new Point(X + 1, Y - 2);

            if (IsNeighbourFunc(neighbour))
            {
                neighbours.Add(neighbour);
            }

            return neighbours;
        }
    }
}
