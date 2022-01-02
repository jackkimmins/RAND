using System;
using OpenCvSharp;
using System.Runtime.InteropServices;

namespace RAND
{
    class Program
    {
        static void Main(string[] args)
        {
            RAND random = new RAND();
            
            while (true)
            {
                Console.WriteLine(random.Next(1, 100));
                Console.ReadLine();
            }
        }
    }
}
