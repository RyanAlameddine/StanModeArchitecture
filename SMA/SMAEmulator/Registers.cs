using System;
using System.Collections.Generic;
using System.Text;

namespace SMAEmulator
{
    class Registers
    {
        private ushort[] registers = new ushort[255];

        public ushort this[int index]
        {
            get
            {
                return registers[index];
            }
            set
            {
                registers[index] = value;
            }
        }
    }
}
