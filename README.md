# RAND
Random Numbers Seeded with WebCam Feed

1. Gets frame from video source using OpenCV.
2. Converts it to a byte array.
3. Hashes it using CRC32 to get an int.
4. Use that int to seed the Random generator.