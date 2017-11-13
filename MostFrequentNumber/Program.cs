using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input.txt").Split(' ')
                .Select(int.Parse).ToArray();

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 0;
                }
                dict[input[i]] += 1;
            }

            File.WriteAllText("output.txt", dict.OrderByDescending(n => n.Value).First().Key.ToString());
        }
    }
}
