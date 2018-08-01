using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
