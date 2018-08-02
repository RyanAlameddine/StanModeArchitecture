using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SMAEmulator
{
    class MMIO
    {
        Thread thread;

        public MMIO(MemoryMap map)
        {
            thread = new Thread(() =>
            {
                Console.WriteLine("Loaded");
                while (true)
                {
                    if (map[8] == 1)
                    {
                        Console.Clear();

                        int i = 0;
                        for (int x = 0; x < 20; x++)
                        {
                            for (int y = 0; y < 20; y++)
                            {
                                int index = map[i + 9];
                                while (index > 15)
                                {
                                    index -= 16;
                                }
                                Console.BackgroundColor = (ConsoleColor)index;
                                Console.Write("  ");
                                i++;
                            }
                            Console.WriteLine();
                            
                        }
                        Thread.Sleep(20);
                        Console.BackgroundColor = ConsoleColor.Black;
                        map[8] = 0;

                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }


        public void Update(MemoryMap map, Random rand)
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
