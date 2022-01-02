using System;
using OpenCvSharp;
using System.Runtime.InteropServices;

namespace RAND
{
    class RAND
    {
        private VideoCapture capture = new VideoCapture(1);
        private byte[] WebCamSeeder()
        {
            if (!capture.IsOpened())
                throw new Exception("WebCam Capture Failed to Open.");

            Mat frame = new Mat();

            capture.Read(frame);

            byte[] data = new byte[frame.Total() * frame.ElemSize()];
            Marshal.Copy(frame.Data, data, 0, data.Length);

            return data;
        }

        public int Next(int start, int end)
        {
            Random rng = new Random(BitConverter.ToInt32(WebCamSeeder(), 0));
            return rng.Next(start, end);
        }
    }
}
