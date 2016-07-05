//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace _6.Snakes
//{
//    class Snakes
//    {
//        static char[] charsRotated = new char[] { 'R', 'U', 'L', 'D' };
//        static StringBuilder snake;
//        static HashSet<string> madeSnakes = new HashSet<string>();
//        static HashSet<Tuple<int, int>> snakePoints = new HashSet<Tuple<int, int>>();
//        const char Right = 'R';
//        const char Up = 'U';
//        const char Left = 'L';
//        const char Down = 'D';
//        const char Start = 'S';
//        static int n;
//        static int count = 0;

//        static void Main()
//        {
//            n = int.Parse(Console.ReadLine());
//            snake = new StringBuilder(n);
//            snake.Append(Start);
//            snake.Append(Right);
//            snakePoints.Add(GetTuple(0, 0));
//            DateTime start = DateTime.Now;
//            GenerateSnakes();
//            Console.WriteLine("Snakes count = {0}", count);
//            Console.WriteLine(DateTime.Now - start);
//        }

//        static void GenerateSnakes(int depth = 2, int x = 1, int y = 0)
//        {
//            if (depth == 1 || IsMoveValid(x, y))
//            {
//                var coordTuple = GetTuple(x, y);
//                if (depth == n)
//                {
//                    if (IsSnakeUnique())
//                    {
//                        //Print();
//                        ++count;
//                    }
//                    snakePoints.Add(coordTuple);
//                    madeSnakes.Add(snake.ToString());

//                }
//                else
//                {
//                    snakePoints.Add(coordTuple);
//                    madeSnakes.Add(snake.ToString());
//                    // Right
//                    snake.Append(Right);
//                    GenerateSnakes(depth + 1, x + 1, y);
//                    snake.Remove(snake.Length - 1, 1);

//                    // Down
//                    snake.Append(Down);
//                    GenerateSnakes(depth + 1, x, y + 1);
//                    snake.Remove(snake.Length - 1, 1);

//                    // Left
//                    snake.Append(Left);
//                    GenerateSnakes(depth + 1, x - 1, y);
//                    snake.Remove(snake.Length - 1, 1);

//                    // Up
//                    snake.Append(Up);
//                    GenerateSnakes(depth + 1, x, y - 1);
//                    snake.Remove(snake.Length - 1, 1);
//                }
//                snakePoints.Remove(coordTuple);
//            }
//        }

//        static Tuple<int, int> GetTuple(int a, int b)
//        {
//            return new Tuple<int, int>(a, b);
//        }

//        static bool IsSnakeUnique()
//        {
//            string rotatedSnake = ReverseSnake(snake.ToString());
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = FlipSnake(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            rotatedSnake = RotateSnake90Deg(rotatedSnake);
//            if (madeSnakes.Contains(rotatedSnake))
//            {
//                return false;
//            }
//            return true;
//        }

//        static bool IsMoveValid(int x, int y)
//        {
//            if (!snakePoints.Contains(GetTuple(x, y)))
//            {
//                string rotatedSnake = RotateSnake90Deg();
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = RotateSnake90Deg(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = RotateSnake90Deg(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = FlipSnake(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = RotateSnake90Deg(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = RotateSnake90Deg(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                rotatedSnake = RotateSnake90Deg(rotatedSnake);
//                if (madeSnakes.Contains(rotatedSnake))
//                {
//                    return false;
//                }
//                return true;
//            }
//            return false;
//        }

//        //static KeyValuePair<int, int> GetIndex(char c)
//        //{
//        //    KeyValuePair<int, int> pair = new KeyValuePair<int,int>();
//        //    switch(c)
//        //    {
//        //        case Right: return 
//        //        case Up: return Left;
//        //        case Left: return Down;
//        //        case Down: return Right;
//        //        default: return Right;
//        //    }
//        //}

//        static void Print()
//        {
//            Console.WriteLine("{0}", string.Join("", snake));
//        }

//        static string ReverseSnake(string strSnake)
//        {
//            StringBuilder reversedSnake = new StringBuilder(snake.Length);
//            reversedSnake.Append(Start);
//            for (int i = strSnake.Length - 1; i > 0; --i)
//            {
//                if (strSnake[i] == Right)
//                {
//                    reversedSnake.Append(Left);
//                }
//                else if (strSnake[i] == Left)
//                {
//                    reversedSnake.Append(Right);
//                }
//                else if (strSnake[i] == Down)
//                {
//                    reversedSnake.Append(Up);
//                }
//                else if (strSnake[i] == Up)
//                {
//                    reversedSnake.Append(Down);
//                }
//            }
//            return reversedSnake.ToString();
//        }

//        static string FlipSnake(string strSnake)
//        {
//            StringBuilder rotatedSnake = new StringBuilder(snake.Length);
//            for (int i = 0; i < strSnake.Length; i++)
//            {
//                if (strSnake[i] == Right)
//                {
//                    rotatedSnake.Append(Left);
//                }
//                else if (strSnake[i] == Left)
//                {
//                    rotatedSnake.Append(Right);
//                }
//                else
//                {
//                    rotatedSnake.Append(strSnake[i]);
//                }
//            }
//            return rotatedSnake.ToString();
//        }

//        static string RotateSnake90Deg(string strSnake)
//        {
//            StringBuilder rotatedSnake = new StringBuilder(strSnake.Length);

//            for (int i = 0; i < strSnake.Length; i++)
//            {
//                rotatedSnake.Append(Rotate90Deg(strSnake[i]));
//            }

//            return rotatedSnake.ToString();
//        }

//        static string RotateSnake90Deg()
//        {
//            StringBuilder rotatedSnake = new StringBuilder(snake.Length);

//            for (int i = 0; i < snake.Length; i++)
//            {
//                rotatedSnake.Append(Rotate90Deg(snake[i]));
//            }

//            return rotatedSnake.ToString();
//        }

//        static char Rotate90Deg(char c)
//        {
//            switch(c)
//            {
//                case Right: return Up;
//                case Up: return Left;
//                case Left: return Down;
//                case Down: return Right;
//                default: return Start;
//            }
//        }
//    }
//}
