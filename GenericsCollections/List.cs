using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsCollections
{
    public class ListFunctions
    {
        public static void ShowList(){

        List <string> names = new List<string> {"IronMan", "Captain America", "Hulk", "Thor", "Black Widow", "Hawkeye", "Spider", "Black Panther", "Doctor Strange", "Nebula", "Star-Lord", "Gamora", "Rocket Raccoon", "Drax"};

        names.Add("Vision");
        names.Add("Scarlet Witch");
        names.Remove("Drax");

        System.Console.WriteLine("List View");
        names.Sort();
        
        foreach (var Name in names)
        {
            System.Console.WriteLine($"{names.IndexOf(Name)}: {Name}");
        }

        System.Console.WriteLine();
        // System.Console.WriteLine("The Index of IronMan is {0}",names.IndexOf("IronMan"));

        }
}
}