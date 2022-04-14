using System;

namespace c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] names = { "Maria","João"};
           Console.WriteLine($"Nomes: {names[0]} e {names[1]}!");

           for (int i = 0; i < 2; i++)
           {
               Console.WriteLine(names[i]);
               
           }
        }
    }
}
