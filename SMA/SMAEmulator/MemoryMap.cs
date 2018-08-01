using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SMAEmulator
{
    class MemoryMap
    {
        private ushort[] memory = new ushort[0x10000];

        public MemoryMap(ReadOnlySpan<byte> programData)
        {
            Span<ushort> memorySpan = memory.AsSpan();
            Span<ushort> programSpace = memorySpan.Slice(0x8000);
            Span<byte> programByteSpace = MemoryMarshal.AsBytes(programSpace);

            programData.CopyTo(programByteSpace);
        }

        public ref ushort this[int index]
        {
            get
            {
                return ref memory[index];
            }
        }

        public Memory<ushort> GetMemoryMappedIO()
        {
            
            return memory.AsMemory().Slice(0, 128);
        }

        public ReadOnlySpan<byte> ProgramSpace => MemoryMarshal.AsBytes(memory.AsSpan().Slice(0x8000));
        
    }
}
