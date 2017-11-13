using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            List<int> list = input.Split(' ').Select(int.Parse).ToList();
            int start = 0; int len = 1;
            int bestStart = 0; int bestLen = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    if (len == 1)
                    {
                        start = i;
                    }
                    len++;
                    if (len > bestLen)
                    {
                        bestStart = start;
                        bestLen = len;
                    }
                }
                else
                {
                    start = 0;
                    len = 1;
                }
            }

            File.WriteAllText("output.txt", string.Join(" ", list.GetRange(bestStart, bestLen)));
        }
    }
}
