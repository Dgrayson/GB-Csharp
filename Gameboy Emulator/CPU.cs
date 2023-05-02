using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static Gameboy_Emulator.MMU; 

namespace Gameboy_Emulator
{
    class CPU
    {
        private MMU _mmu; 

        private byte A, B, C, D, E, F, H, L;

        private ushort AF;
        private ushort BC;
        private ushort DE;
        private ushort HL;

        private ushort SP;
        private ushort PC;

        private bool FlagZ, FlagN, FlagH, FlagC;

        public CPU(MMU mmu)
        {
            this._mmu = mmu;

            A = 0x01;
            B = 0xFF;
            C = 0x13;
            D = 0x00;
            E = 0xC1;
            H = 0x84;
            L = 0x03;

            PC = 0x0100;
            SP = 0xFFFE; 
        }

        public void execute()
        {
            byte opcode = _mmu.ReadByte(PC);
            bool jumped = false; 

            String hex = String.Format("{0:x2}", opcode);
            Console.WriteLine("Opcode is: {0}", hex);
            System.Threading.Thread.Sleep(1000);

            switch (opcode)
            {
                case 0x00: break; // NOP
                case 0x0f:
                    F = 0;
                    FlagC = ((A & 0x1) != 0);
                    A = (byte)((A >> 1) | (A << 7));
                    break;
                case 0x17:
                    break; 
                case 0x1f:
                    bool preC = FlagC;
                    F = 0;
                    FlagC = ((A & 0x1) != 0);
                    A = (byte)((A >> 1) | (preC ? 0x80 : 0));
                    break; 

                case 0x2f: { A = (byte)~A; FlagN = true; FlagH = true; break; }
                // Loads
                case 0x40: { B = B; break; }
                case 0x41: { B = C; break; }
                case 0x42: { B = D; break; }
                case 0x43: { B = E; break; }
                case 0x44: { B = H; break; }
                case 0x45: { B = L; break; }
                //case 0x46: { B = HL; break; }
                case 0x47: { B = A; break; }
                case 0x48: { C = B; break; }
                case 0x49: { C = C; break; }
                case 0x4A: { C = D; break; }
                case 0x4B: { C = E; break; }
                case 0x4C: { C = H; break; }
                case 0x4D: { C = L; break; }
                // case 0x4E: {C = HL; break; }
                case 0x4F: { C = A; break; }
                case 0x50: { D = B; break; }
                case 0x51: { D = C; break; }
                case 0x52: { D = D; break; }
                case 0x53: { D = E; break; }
                case 0x54: { D = H; break; }
                case 0x55: { D = L; break; }
                //case 0x56: { D = HL; break; }


                // Additon 
                case 0x80: { 
                        A += B;    


                        break; 
                    }
                case 0x81: { A += C;    break; }
                case 0x82: { A += D;    break; }
                case 0x83: { A += E;    break; }
                case 0x84: { A += H;    break; }
                //case 0x85: { A += HL;   break; }
                case 0x86: { A += A;    break; }

                case 0xC3: {
              

                        PC = (ushort)((_mmu.ReadByte(PC++) << 8) | _mmu.ReadByte(PC++)); 
                        jumped = true;  
                        break; 
                    }
                default: { Console.WriteLine("Unimplemented OpCode"); break; } 
            }

            if (!jumped)
                PC++; 
        }

        public void LoadRegister() { }
        public void LoadRegisterImmediate() { }
    }
}
