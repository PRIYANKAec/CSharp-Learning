using System;

namespace Task_2
{
    public class Oops
    {
        public static void Main(string[] args)
        {
            try
            {
                Person person1 = new Person("Robert Downey Jr", 60);
                Person person2 = new Person("Chris Hemsworth", 44);
                Person person3 = new Person("Chris Evans", 42);
                Person person4 = new Person();
                
                person1.Introduce();
                person2.Introduce();
                person3.Introduce();
                person4.Introduce();
            }
            catch (Exception e)
            {      
                System.Console.WriteLine("The occured error is : {0}", e.Message);
            }
            
        }
    }
}