using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Словари
{
    class Program
    {
        static void Main()
        {
            var birthdays = new Dictionary<string, double>();
            using (var file = new StreamReader("birthdays.txt", Encoding.Default))
            {
                while (!file.EndOfStream)
                {
                    var key = file.ReadLine().Split('\t')[1];
                    if (birthdays.ContainsKey(key))
                        birthdays[key]++;
                    else
                        birthdays[key] = 1;
                }
            }

            var list = birthdays.ToList();
            list.Sort((x, y) => -x.Value.CompareTo(y.Value));
            int i;

            for (i = 0; i < 20; i++)
                Console.WriteLine($"{list[i].Key} - {list[i].Value}");

            Console.ReadKey();
        }
    }
}

