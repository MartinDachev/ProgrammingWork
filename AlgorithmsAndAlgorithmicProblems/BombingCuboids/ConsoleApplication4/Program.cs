using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombingCuboids
{
    class Program
    {
        static char[,,] cube;
        static char[] separators = { ' ' };
        static SortedDictionary<char, int> explodedCubesColors = new SortedDictionary<char, int>();
        //static int[] explodedCubesColors = new int['Z' - 'A' + 1];
        static int w;
        static int h;
        static int d;
        static int p;
        static int total=0;

        static void ReadCubeInfo()
        {
            string dimensions = Console.ReadLine();
            string[] dimensionsArray = dimensions.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int width = int.Parse(dimensionsArray[0]);
            int height = int.Parse(dimensionsArray[1]);
            int depth = int.Parse(dimensionsArray[2]);
            cube = new char[width, height, depth];
            string[] colorSequences;
            string colorInput;
            for (int i = 0; i < height; i++)
            {
                colorInput = Console.ReadLine();
                colorSequences = colorInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0, c=0; j < depth; j++, c += (width+1))
                {
                    for (int k = 0; k < width; k++)
                    {
                        cube[k, i, j] = colorSequences[j][k];
                    }
                }
            }
        }
        static void DetonateBomb(int width, int height, int depth, int power)
        {
            //Formula - distance = sqrt(width*width + height*height + depth*depth
            int widthStart = Math.Max(width - power, 0);
            int widthEnd = Math.Min(width + power, cube.GetLength(0) - 1);
            int heightStart = Math.Max(height - power, 0);
            int heightEnd = Math.Min(height + power, cube.GetLength(1) - 1);
            int depthStart = Math.Max(depth - power, 0);
            int depthEnd = Math.Min(depth + power, cube.GetLength(2) - 1);
            for (int i = widthStart; i <= widthEnd; i++)
            {
                for (int j = heightStart; j <= heightEnd; j++)
                {
                    for (int k = depthStart; k <= depthEnd; k++)
                    {
                        double distanceFromBomb = Math.Sqrt((i - width)*(i - width) + (j - height)*(j - height) + (k-depth)*(k-depth));
                        if (distanceFromBomb <= power && cube[i, j, k]!= '0')
                        {
                            if (explodedCubesColors.ContainsKey(cube[i, j, k]))
                            {
                                explodedCubesColors[cube[i, j, k]]++;
                            }
                            else
                            {
                                explodedCubesColors.Add(cube[i, j, k], 1);
                            }

                            //explodedCubesColors[cube[i, j, k] - 'A']++;
                           
                            cube[i, j, k] = '0';
                            total++;
                        }
                    }
                }
            }
            MoveCubes(widthStart, widthEnd, heightStart, heightEnd, depthStart, depthEnd);
        }
        static void MoveCubes(int widthStart, int widthEnd, int heightStart, int heightEnd, int depthStart, int depthEnd)
        {
            for (int i = widthStart; i <= widthEnd; i++)
            {
                for (int j = depthStart; j <= depthEnd; j++)
                {
                    int holes = 0;
                    for (int k = 0; k < cube.GetLength(1); k++)
                    {

                        if (cube[i, k, j] != '0')
                        {
                            if (holes != 0)
                            {
                                cube[i, k - holes, j] = cube[i, k, j];
                                cube[i, k, j] = '0';
                            }

                        }
                        else holes++;

                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ReadCubeInfo();
            int n = int.Parse(Console.ReadLine());
            string bombInput;
            string[] whdp;
            for (int i = 0; i < n; i++)
            {
                bombInput = Console.ReadLine();
                whdp = bombInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                w = int.Parse(whdp[0]);
                h = int.Parse(whdp[1]);
                d = int.Parse(whdp[2]);
                p = int.Parse(whdp[3]);
                DetonateBomb(w, h, d, p);
            }
            Console.WriteLine(total);
            //for (char color = 'A'; color <= 'Z'; color++)
            //{
            //    int count = explodedCubesColors[color - 'A'];
            //    if (count > 0)
            //    {
            //        Console.WriteLine("{0} {1}", color, count);
            //    }
            //}
            foreach (char key in explodedCubesColors.Keys)
            {

                Console.WriteLine("{0} {1}", key, explodedCubesColors[key]);
            }
        }
    }
}
