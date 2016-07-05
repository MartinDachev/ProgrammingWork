using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_Ride_The_Horse
{
    class RideTheHorse
    {
        static int n;
        static int m;

        static bool IsCellOnBoard(Point cell)
        {
            return (cell.X >= 0 && cell.X < n && cell.Y >= 0 && cell.Y < m);
        }

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int numberOfCells = n * m;
            Queue<Point> bfsQueue = new Queue<Point>();
           
            Point currentCell = new Point(r, c);
            currentCell.Value = 1;
            matrix[r, c] = 1;
            bfsQueue.Enqueue(currentCell);

            while (bfsQueue.Count > 0)
            {
                currentCell = bfsQueue.Dequeue();

                foreach (var neighbourCell in currentCell.GetNeighbours(IsCellOnBoard))
                {
                    if (matrix[neighbourCell.X, neighbourCell.Y] == 0)
                    {
                        neighbourCell.Value = currentCell.Value + 1;
                        matrix[neighbourCell.X, neighbourCell.Y] = neighbourCell.Value;
                        bfsQueue.Enqueue(neighbourCell);
                    }
                }
            }

            int j = m / 2;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(matrix[i, j]);
            }
        }
    }
}
