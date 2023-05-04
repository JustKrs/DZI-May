using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zad28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();

            int k = int.Parse(Console.ReadLine());

            var list = GetListFromFile(fileName);

            list = RemoveElementsBySum(list, k);

            list = SortListBySumOfNumbersDigits(list);

            Console.WriteLine(string.Join(" ", list));
        }

        public static List<int> RemoveElementsBySum(List<int> list, int k)
        {
            list = list.Where(x => FindSumOfNumbersDigits(x) % k != 0).ToList();
            return list;
        }

        public static int FindSumOfNumbersDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number = number / 10;
            }

            return sum;
        }

        public static List<int> SortListBySumOfNumbersDigits(List<int> list)
        {
            list = list.OrderBy(x => FindSumOfNumbersDigits(x)).ToList();

            return list;
        }

        public static List<int> GetListFromFile(string fileName)
        {
            try
            {
                List<int> list = new List<int>();

                StreamReader sr = new StreamReader(fileName);
                string line = sr.ReadLine();
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    list.Add(int.Parse(line));
                }

                return list;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error has occurred while getting numbers from the file:" + e.Message);
            }
        }
    }
}
