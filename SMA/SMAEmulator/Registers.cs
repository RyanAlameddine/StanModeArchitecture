using System;
using System.Collections.Generic;
using System.Text;

namespace SMAEmulator
{
    class Registers
    {
        private ushort[] registers = new ushort[255];

        public ref ushort this[int index]
        {
            get
            {
                return ref registers[index];
            }
        }
    }
}
