using System;
using System.Collections.Generic; //can run without mentioning this namespace, but it's good practice to include it

namespace Task_3
{
    public class ListConcept
    {
    public static void Main(string[] args)
    {
        List<string> Names = new List<string> { "IronMan", "Hulk", "Thor", "Captain America" };

        System.Console.WriteLine("To add names to the list, Press 1\nTo remove names from the list, Press 2\nTo display the names in the list, Press 3");
        
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
            System.Console.WriteLine("Enter an Name to add to the Avengers List");
            string newName = Console.ReadLine();
            Names.Add(newName);
            System.Console.WriteLine($"{newName} is added to the List");
            System.Console.WriteLine("The new Avengers List is :");
            foreach (var names in Names)
            {
            System.Console.WriteLine($"{names.ToUpper()}");   
            }
            break;

            case 2:
            System.Console.WriteLine("Enter an Name to remove from the Avengers List");
            string removeName = Console.ReadLine();
            if(Names.Contains(removeName))
            {
                Names.Remove(removeName);
                System.Console.WriteLine($"{removeName} is removed from the List");
            }
            else
            {
                System.Console.WriteLine($"{removeName} is not in the List");
            }
            System.Console.WriteLine("The new Avengers List is :");
            foreach (var names in Names)
            {
            System.Console.WriteLine($"{names.ToUpper()}");   
            }
            break;

            case 3:
            foreach (var names in Names)
            {
            System.Console.WriteLine($"{names.ToUpper()}");   
            }
            break;

            default:
            System.Console.WriteLine("Invalid choice, please try again.");
            break;
        }        
    }
}
}