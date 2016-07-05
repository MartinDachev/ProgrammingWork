using System;
using System.Collections.Generic;
using System.Text;

public class EscapeFromLabyrinth
{
    static int width = 9;
    static int height = 7;
    const char VisitedCell = 's';
    static char[,] labyrinth =
    {
        { '*', '*', '*', '*', '*', '*', '*', '*', '*'},
        { '*', '-', '-', '-', '-', '*', '*', '-', '-'},
        { '*', '*', '-', '*', '-', '-', '-', '-', '*'},
        { '*', '-', '-', '*', '-', '*', '-', '*', '*'},
        { '*', 's', '*', '-', '-', '*', '-', '*', '*'},
        { '*', '*', '-', '-', '-', '-', '-', '-', '*'},
        { '*', '*', '*', '*', '*', '*', '*', '-', '*'}
    };

    static Point FindStartPosition()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (labyrinth[i, j] == VisitedCell)
                {
                    return new Point()
                    {
                        X = j,
                        Y = i
                    };
                }
            }
        }

        return null;
    }

    static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;

        return isOnBorderX || isOnBorderY;
    }

    static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;

        if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newY, newX] == '-')
        {
            labyrinth[newY, newX] = VisitedCell;
            var nextCell = new Point()
            {
                X = newX,
                Y = newY,
                Direction = direction,
                PreviousPoint = currentCell
            };

            queue.Enqueue(nextCell);
        }
    }

    static void BuildPath(Point currentCell, ref StringBuilder pathSB)
    {
        if (currentCell != null)
        {
            BuildPath(currentCell.PreviousPoint, ref pathSB);
            pathSB.Append(currentCell.Direction);
        }
    }

    static string TracePathBack(Point currentCell)
    {
        StringBuilder pathSB = new StringBuilder();

        BuildPath(currentCell, ref pathSB);

        return pathSB.ToString();
    }

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();

        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();

            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", +1, 0);
            TryDirection(queue, currentCell, "D", 0, +1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }

        return null;
    }

    static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new char[height, width];
        string labyrinthLine;

        for (int row = 0; row < height; row++)
        {
            labyrinthLine = Console.ReadLine();

            for (int column = 0; column < labyrinthLine.Length; column++)
            {
                labyrinth[row, column] = labyrinthLine[column];
            }
        }
    }

    public static void Main()
    {
        ReadLabyrinth();
        string shortestPathToExit = FindShortestPathToExit();

        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPathToExit);
        }
    }
}
