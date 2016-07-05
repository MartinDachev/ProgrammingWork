namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] prev = new int[sequence.Length];
            int[] len = new int[sequence.Length];
            int maxLen = -1;
            int lastIndex = -1;
            for (int x = 0; x < sequence.Length; ++x)
            {
                prev[x] = -1;
                len[x] = 1;
                for (int i = 0; i < x; ++i)
                {
                    if (sequence[i] < sequence[x] && len[i] + 1 > len[x])
                    {
                        len[x] = len[i] + 1;
                        prev[x] = i;
                    }
                }
                if (maxLen < len[x])
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            var longestSeq = new List<int>(maxLen);
            while (lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
