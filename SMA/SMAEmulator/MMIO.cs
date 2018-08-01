using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SMAEmulator
{
    class MMIO
    {
        public static void Update(MemoryMap map, Random rand)
        {
            map[1] = (ushort) rand.Next();
            if(map[3] == 1)
            {
                map[3] = 0;
                Console.Write(map[2]);
            }
            if(map[5] == 1)
            {
                map[5] = 0;
                map[4] = Console.ReadKey().KeyChar;
            }
            if(map[7] == 1)
            {
                map[7] = 0;
                Console.Write((char)map[6]);
            }
            if(map[8] == 1)
            {
                Console.Clear();
                int i = 0;
                for(int x = 0; x < 10; x++)
                {
                    for(int y = 0; y < 10; y++)
                    {
                        Console.Write((char)map[i + 9]);
                        i++;
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(50);
            }
        }
    }
}
