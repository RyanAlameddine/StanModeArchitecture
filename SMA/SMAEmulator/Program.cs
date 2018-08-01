using SMA;
using System;
using System.IO;

namespace SMAEmulator
{
    class Program
    {
        static MemoryMap memMap;
        static Registers r;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            memMap = new MemoryMap(File.ReadAllBytes(args[0]));
            r = new Registers();

            MMIO.Update(memMap, rand);

            //SP
            r[254] = 0x7FFF;
            //IP
            r[253] = 0x8000;

            while(memMap[0] == 0)
            {
                string opCode = Enum.GetName(typeof(OpCode), memMap.ProgramSpace.Slice((r[253] - 0x8000) * 2, 4)[0]) + ": " + ((r[253] - 0x8000)/2);
                Execute();
                MMIO.Update(memMap, rand);
            }
            Console.ReadKey();
        }

        static void Execute()
        {
            ReadOnlySpan<byte> p = memMap.ProgramSpace;
            p = p.Slice((r[253] - 0x8000)*2, 4);
            OpCode opCode = (OpCode)p[0];

            switch (opCode)
            {
                case OpCode.noOp:
                    break;
                case OpCode.add:
                    r[p[1]] = (ushort) (r[p[2]] + r[p[3]]);
                    break;
                case OpCode.sub:
                    r[p[1]] = (ushort)(r[p[2]] - r[p[3]]);
                    break;
                case OpCode.mult:
                    r[p[1]] = (ushort)(r[p[2]] * r[p[3]]);
                    break;
                case OpCode.div:
                    r[p[1]] = (ushort)(r[p[2]] / r[p[3]]);
                    break;
                case OpCode.mod:
                    r[p[1]] = (ushort)(r[p[2]] % r[p[3]]);
                    break;
                case OpCode.rSft:
                    r[p[1]] = (ushort)(r[p[2]] >> r[p[3]]);
                    break;
                case OpCode.lSft:
                    r[p[1]] = (ushort)(r[p[2]] << r[p[3]]);
                    break;
                case OpCode.not:
                    r[p[1]] = (ushort)(~r[p[2]]);
                    break;
                case OpCode.and:
                    r[p[1]] = (ushort)(r[p[2]] & r[p[3]]);
                    break;
                case OpCode.or:
                    r[p[1]] = (ushort)(r[p[2]] | r[p[3]]);
                    break;
                case OpCode.xor:
                    r[p[1]] = (ushort)(r[p[2]] ^ r[p[3]]);
                    break;
                case OpCode.eql:
                    r[p[1]] = r[p[2]] == r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.grtr:
                    r[p[1]] = r[p[2]] > r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.less:
                    r[p[1]] = r[p[2]] < r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.nEql:
                    r[p[1]] = r[p[2]] != r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.grtE:
                    r[p[1]] = r[p[2]] >= r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.lssE:
                    r[p[1]] = r[p[2]] <= r[p[3]] ? (ushort)1 : (ushort)0;
                    break;
                case OpCode.tp:
                    r[253] = (ushort) (ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber)*2 + 0x8000);
                    r[253]-=2;
                    break;
                case OpCode.tpZ:
                    if(r[p[1]] == 0)
                    {
                        r[253] = (ushort) (ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber)*2 + 0x8000);
                        r[253]-=2;
                    }
                    break;
                case OpCode.tpNZ:
                    if(r[p[1]] != 0)
                    {
                        r[253] = (ushort) (ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber)*2 + 0x8000);
                        r[253]-=2;
                    }
                    break;
                case OpCode.load:
                    r[p[1]] = memMap[ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber)];
                    break;
                case OpCode.unld:
                    memMap[ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber)] = r[p[1]];
                    break;
                case OpCode.push:
                    memMap[r[254]] = r[p[3]];
                    r[254]--;
                    break;
                case OpCode.pop:
                    r[254]++;
                    r[p[3]] = memMap[r[254]];
                    break;
                case OpCode.peek:
                    r[p[3]] = memMap[r[254] + 1];
                    break;
                case OpCode.set:
                    r[p[1]] = ushort.Parse(p[2].ToString("X") + p[3].ToString("X").PadLeft(2, '0'), System.Globalization.NumberStyles.HexNumber);
                    break;
                case OpCode.mov:
                    r[p[2]] = r[p[3]];
                    break;
                case OpCode.call:
                    memMap[r[254]] = (ushort) (r[253] + 2);
                    r[254]--;
                    break;
                case OpCode.ret:
                    r[254]++;
                    ushort returnAddr = memMap[r[254]];
                    r[253] = returnAddr;
                    r[253] += 2;
                    break;
            }
            r[253] += 2;
        }
    }
}
