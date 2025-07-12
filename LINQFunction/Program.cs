using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFucntion
{
    public class QuerySyntax
    {
        public static void Main(string[] args)
        {
            List <int> num = new List<int> { 1, 2, 23, 3, 4, 5, 6, 7, 8, 9, 10 };

            var even = from n in num
                       where n % 2 == 0
                       select n;

            foreach (var item in even)
            {
                System.Console.WriteLine(item);
            }
             System.Console.ReadKey();
        }
    }
}
