using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RailwayJunction
{
    class Program
    {
        static void Main()
        {
            var maneuverQueue = new Queue<string>();
            var queue = new Queue<string>();
            var stack = new Stack<string>();
            var trainCounter = 0;
            var maneueverCounter = 0;

            Console.WriteLine("Начало обработки данных");

            try
            {
                using (StreamReader sr = new StreamReader("carriages.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                        queue.Enqueue(line);
                }
            }
            catch { }

            trainCounter = queue.Count;
            string train;

            while (queue.Count != 0)
            {
                train = queue.Dequeue();
                if (train[0] != 'A')
                {
                    stack.Push(train);
                    maneuverQueue.Enqueue($"Вагон {train} перегнать на запасной путь C");
                }
                else
                {
                    maneuverQueue.Enqueue($"Вагон {train} перегнать на погрузку на путь A");
                }
            }

            while (stack.Count != 0)
            {
                train = stack.Pop();
                maneuverQueue.Enqueue($"Вагон {train} перегнать на погрузку на путь B");
            }

            maneueverCounter = maneuverQueue.Count;

            try
            {
                using (StreamWriter sr = new StreamWriter("orders.txt", false, Encoding.Default))
                {
                    while (maneuverQueue.Count != 0)
                        sr.WriteLine(maneuverQueue.Dequeue());
                }
            }
            catch { }


            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                Console.Write('.');
            }
            Thread.Sleep(400);
            Console.WriteLine();

            Console.WriteLine($"количество поездов - {trainCounter}");
            Console.WriteLine($"количество маневров - {maneueverCounter}");
            Console.ReadKey();
        }
    }
}