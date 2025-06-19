using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsCollections
{
    public class StackFunctions
    {
       public static void ShowStack()
       {
        Stack<int> s = new Stack<int>();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        s.Push(4);
        s.Push(5);  
        System.Console.WriteLine("\nStack Elements:");
        System.Console.WriteLine("Stack Count: " + s.Count);
     
        while(s.Count >0)
        {
            System.Console.WriteLine(s.Pop()+ "\t");
        }
        System.Console.WriteLine("Stack Count: " + s.Count);
       } 
    }
}