using System;

namespace RAND
{
    class Program
    {
        static void Main(string[] args)
        {     
            RAND random = new RAND();
                   
            while (true)
            {
                random.GenSeed();
                Console.WriteLine(random.Next(1, 100));
                Console.ReadLine();
            }
        }
    }
}
