using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> alphabet = new List<char>();
            for (int i = 97; i < 122; i++)
            {
                alphabet.Add((char)i);
            }
            string input = File.ReadAllText("input.txt");
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                dict[input[i]] = alphabet.IndexOf(input[i]);
            }
            
            File.WriteAllText("output.txt", "");

            foreach (var pair in dict)
            {
                File.AppendAllText("output.txt", pair.Key + " -> "
                    + pair.Value + Environment.NewLine);
            }
        }
    }
}
