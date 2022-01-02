using System;
using OpenCvSharp;
using System.Runtime.InteropServices;

namespace RAND
{
    class RAND
    {
        //Video Capture Object
        private VideoCapture capture = new VideoCapture(1);

        public RAND()
        {
            GenSeed();
        }

        public int Seed { get; set; }

        //Get the frame from the camera and returns it as a byte array.
        private byte[] WebCamSeeder()
        {
            //Check if the camera is open.
            if (!capture.IsOpened())
                throw new Exception("WebCam Capture Failed to Open.");

            //Create a Mat object to store the frame.
            Mat frame = new Mat();

            //Get the frame from the camera.
            capture.Read(frame);

            //Convert the frame to a byte array.
            byte[] data = new byte[frame.Total() * frame.ElemSize()];
            Marshal.Copy(frame.Data, data, 0, data.Length);

            //Return the byte array.
            return data;
        }

        public void GenSeed()
        {
            //Get the seed from the camera and hash it using CRC32.
            string crc32 = Force.Crc32.Crc32CAlgorithm.Compute(WebCamSeeder()).ToString();

            //We need to remove one character from the end of the string because the CRC32 algorithm returns a uint and the Random class only accepts ints.
            crc32 = crc32.Substring(0, crc32.Length - 1);

            //Output Seed
            //Console.WriteLine("Seed: " + crc32);

            //Set the seed.
            Seed = int.Parse(crc32);
        }

        //Generates a random number between the given range.
        public int Next(int start, int end)
        {
            //Create a new Random object with the seed.
            Random rng = new Random(Seed);

            //Return a random number between the given range.
            return rng.Next(start, end);
        }
    }
}
