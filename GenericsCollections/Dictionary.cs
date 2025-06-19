using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsCollections
{
    public class DictionaryFunctions
    {
        public static void ShowDictionary()
        {
            Dictionary<string , string> Avengers = new Dictionary<string, string>
            {
                {"Tony Stark", "IronMan"},
                {"Steve Rogers", "Captain America"},
                {"Bruce Banner", "Hulk"},
                {"Odinson", "Thor"},
                {"Natasha Romanoff", "Black Widow"},
                {"Clint Barton", "Hawkeye"},
                {"TChalla", "Black Panther"},
                {"Wanda Maximoff", "Scarlett Witch"},
                {"Peter Parker", "SpiderMan"},
                {"Scoot Land", "AntMan"},
                {"Doctor Strange", "Doctor Strange"},
                {"Sam Wilson", "Falcon"},
                {"Bucky Barnes", "Winter Soldier"},
                {"Carol Danvers", "Captain Marvel"}
            };

            System.Console.WriteLine("Dictionary View");
            System.Console.WriteLine("Key Value Pair");
            foreach (var avenger in Avengers)
            {
                // Console.WriteLine($"Character Name: {avenger.Key} => Avenger Name: {avenger.Value}");
                Console.WriteLine($"{avenger.Key} =>{avenger.Value}");
            }
        }
    }
}