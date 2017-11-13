using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();
            string[] input = File.ReadAllLines("input.txt");
            for (int i = 0; i < input.Length - 1; i+=2)
            {
                string name = input[i];
                string email = input[i + 1];
                string em = email.ToLower();
                if (!(em.EndsWith(".uk") || em.EndsWith(".us")))
                {
                    emails[name] = em;
                }
            }

            File.WriteAllText("output.txt", "");
            foreach (var pair in emails)
            {
                File.AppendAllText("output.txt",$"{pair.Key} -> {pair.Value}{Environment.NewLine}");

            }
        }
    }
}
