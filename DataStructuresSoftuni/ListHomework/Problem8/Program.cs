using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8
{
    class Program
    {
        static int[,] m;
        static bool[,] b;

        static void SetLen(int i, int j, int len)
        {
            if (i < 0 || i >= m.GetLength(0) || j < 0 || j >= m.GetLength(1) || m[i, j] != 0 || b[i, j])
            {
                return;
            }

            m[i, j] = len;
        }

        static void Fill(int i, int j)
        {
            if (i < 0 || i >= m.GetLength(0) || j < 0 || j >= m.GetLength(1) || b[i, j] || m[i, j] == -1)
            {
                return;
            }

            b[i, j] = true;
            int len = m[i, j] + 1;
            SetLen(i - 1, j, len);
            SetLen(i, j - 1, len);
            SetLen(i, j + 1, len);
            SetLen(i + 1, j, len);

            Fill(i - 1, j);
            Fill(i, j - 1);
            Fill(i, j + 1);
            Fill(i + 1, j);
        }

        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int startI = 0, startJ = 0;
            m = new int[length, length];
            b = new bool[length, length];
            string input;

            for (int i = 0; i < length; i++)
            {
                input = Console.ReadLine();
                
                for (int j = 0; j < input.Length; j++)
                {
                    switch (input[j])
                    {
                        case '0': 
                            {
                                m[i, j] = 0;
                                break;
                            }
                        case 'x':
                            {
                                m[i, j] = -1;
                                break;
                            }
                        case '*':
                            {
                                m[i, j] = 0;
                                startI = i;
                                startJ = j;
                            }
                            break;
                    }
                }
            }

            Fill(startI, startJ);

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    switch (m[i, j])
                    {
                        case -1:
                            {
                                Console.Write("x ");
                                break;
                            }
                        case 0:
                            {
                                if (startJ == j && startI == i)
                                {
                                    Console.Write("* ");
                                }
                                else
                                {
                                    Console.Write("u ");
                                }
                                break;
                            }
                        default:
                            {
                                Console.Write(m[i, j] + " ");
                                break;
                            }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
/* 
Input:
6
000x0x
0x0x0x
0*x0x0
0x0000
000xx0
000x0x
 */
