using System;
using System.Collections.Generic;
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

        public CPU()
        {

        }

        public void execute()
        {
            byte opcode = _mmu.ReadByte(PC++);

            switch (opcode)
            {
                case 0x40: { B = B; break; }
                case 0x41: { B = C; break; }
                case 0x42: { B = D; break; }
                case 0x43: { B = E; break; }
                case 0x44: { B = H; break; }
                case 0x45: { B = L; break; }
                //case 0x46: { B = HL; break; }

                // Additon 
                case 0x80: { A += B;    break; }
                case 0x81: { A += C;    break; }
                case 0x82: { A += D;    break; }
                case 0x83: { A += E;    break; }
                case 0x84: { A += H;    break; }
                //case 0x85: { A += HL;   break; }
                case 0x86: { A += A;    break; }  
                default: { break; } 
            }
        }

        public void LoadRegister() { }
        public void LoadRegisterImmediate() { }
    }
}
