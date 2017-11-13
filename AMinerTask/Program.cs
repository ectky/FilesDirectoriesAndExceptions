using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();
            string resource = "a"; int count = 0;
            string[] input = File.ReadAllLines("input.txt");
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    resource = input[i];
                }
                else
                {
                    if (!resources.ContainsKey(resource))
                    {
                        resources[resource] = 0;
                    }
                    resources[resource] += int.Parse(input[i]);
                }
            }

            File.WriteAllText("output.txt", "");
            foreach (var pair in resources)
            {
                File.AppendAllText("output.txt", $"{pair.Key} -> {pair.Value}"+
                    Environment.NewLine);
            }
        }
    }
}