# RAND
Random Numbers Seeded with WebCam Feed

1. Gets frame from video source using OpenCV.
2. Converts it to a byte array.
3. Hashes it using CRC32 to get an int.
4. Use that int to seed the Random generator.

## Demo
```csharp
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
```
