using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input.txt").Split(' ')
                .Select(int.Parse).ToArray();
            var dict = new Dictionary<char, int>();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                leftSum = i == 0 ? 0 : input.Take(i).Sum();
                rightSum = i == input.Length - 1 ? 0 : input.Skip(i + 1).Sum();
                if (leftSum == rightSum)
                {
                    File.WriteAllText("output.txt", i.ToString());
                    return;
                }
            }
            File.WriteAllText("output.txt", "no");

        }
    }
}
