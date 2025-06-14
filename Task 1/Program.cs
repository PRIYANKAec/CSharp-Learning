using System;

namespace DotNetFolder
{
    class PracticeProblems
    {
        private static long Factorial(int n )
        {
            long fact = 1;
            if (n == 0 || n==1)
            {
                return 1;
            }
            for( var i= n ;i>0; i--)
            {
                fact *=i;
            }
            return fact;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to find its factorial");
            var num = Convert.ToInt32(Console.ReadLine()); 
            if (num < 0)
            {
                Console.WriteLine("Enter a positive number");
            }
            else 
            {
            var fact = Factorial(num);
            Console.WriteLine("The factorial of {0} is {1}", num , fact);
            }
        }
    }
    
}