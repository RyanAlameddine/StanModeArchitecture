using System;
using System.IO;

namespace SMAEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = File.ReadAllBytes(args[0]);
        }
    }
}
