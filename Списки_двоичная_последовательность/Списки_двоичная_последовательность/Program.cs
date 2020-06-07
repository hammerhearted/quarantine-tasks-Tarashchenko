using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвоичнаяПоследовательность
{
    class Program
    {
        static void Main()
        {
            var text = "";

            using (StreamReader sr = new StreamReader("binary_sequense.txt"))
            {
                text = sr.ReadToEnd();
            }

            var byteList = ParserText(text);
            var listSorting = new int[byteList.Count];

            byteList.CopyTo(listSorting);
            listSorting.ToList().Sort();
            SpecialNumber(listSorting);
            MaxSequense(byteList);



            Console.ReadKey();
        }


        private static void MaxSequense(List<int> listByte)
        {
            var currentElement = 0;
            var currentList = new List<int>();
            var result = new List<int>();
            foreach (var element in listByte)
            {
                if (currentElement < element)
                    currentList.Add(element);
                else
                {
                    if (result.Count < currentList.Count)
                        result = currentList;
                    currentList = new List<int>();
                }
                currentElement = element;
            }
            if (result.Count == 0)
                result = currentList;

            result.Sort();

            foreach (var element in result)
                Console.Write(element + " ");
        }


        private static void SpecialNumber(int[] sortList)
        {
            var lastElemenet = sortList[0];
            Console.Write(lastElemenet + " ");
            foreach (var element in sortList)
                if (lastElemenet != element)
                {
                    Console.Write(element + " ");
                    lastElemenet = element;
                }
            Console.WriteLine();
        }


        private static List<int> ParserText(string text)
        {
            var newText = text.Replace("\r\n", "");
            var i = 0;
            var result = new List<int>();

            var byteByString = newText.Substring(i, newText.Length % 8);
            result.Add(ConvertToByte(byteByString));
            for (i = newText.Length % 8; i < newText.Length; i += 8)
            {
                byteByString = newText.Substring(i, 8);
                result.Add(ConvertToByte(byteByString));
            }
            return result;
        }

        private static int ConvertToByte(string substring)
        {
            var result = 0;
            for (int i = substring.Length - 1; i > 0; i--)
            {
                if (substring[i] == '1')
                    result += (int)Math.Pow(2, substring.Length - 1 - i);
            }
            return result;
        }
    }
}


