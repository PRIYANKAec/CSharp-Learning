using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsCollections
{
    public class QueueFunctions
    {
        public static void ShowQueue()
        {
            Queue<string> q1 = new Queue<string>();

            q1.Enqueue("Pizza");
            q1.Enqueue("Burger");
            q1.Enqueue("Pasta");
            q1.Enqueue("Sandwich");
            q1.Enqueue("Spaghetti");

            Console.WriteLine("\nQueue elements:");
            foreach(var i in q1)
            {
                Console.Write(i+"\t");
            }

            Console.WriteLine();
            System.Console.WriteLine("Peek Element: "+ q1.Peek() + "\nQueue Count" + q1.Count());

            q1.Clear();
            System.Console.WriteLine( "After clearing the queue: " +q1.Count());

            Queue<object> q2 = new Queue<object>();
            q2.Enqueue("Tea");
            q2.Enqueue("Coffee");
            q2.Enqueue(26);
            q2.Enqueue(3.14);

            System.Console.WriteLine("Queue with different data types:");
            while(q2.Count >0)
            {
                System.Console.WriteLine(q2.Dequeue()+ "\t");
            }
        }
    }
}