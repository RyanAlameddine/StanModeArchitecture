using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace SMAEmulator
{
    class MMIO
    {
        Graphics g;
        Bitmap bitmap = new Bitmap(20, 20);

        public MMIO(MemoryMap map)
        {
            g = Graphics.FromHwnd(Screen.GetConsoleWindow());
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
        }

        public object BitMap { get; }

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
            if (map[8] == 1)
            {

                int i = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int val = (int)(map[i + 9]);
                        val -= 256 * (val / 256);
                        bitmap.SetPixel(y, x, Color.FromArgb(255, 255, val, 255));
                        i++;
                    }

                }
                Screen.DrawImage(g, bitmap, new Point(1, 1), new Size(20, 20));
                map[8] = 0;
            }
        }
    }
}
