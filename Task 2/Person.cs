namespace Task_2
{
    public class Person
    {
        private string name ;
        private int age;
        public Person(string name = "Tom Hiddleston", int age = 42)
        { 
            if( age < 0) throw new ArgumentException("Age cannot be an Negative number");
            this.name = name;
            this.age =age;
        }
        public void Introduce()
        {
         System.Console.WriteLine("Hello Everyone , I am {0} and I am {1} years old! Nice to meet You", name,age);
        }
    }
}