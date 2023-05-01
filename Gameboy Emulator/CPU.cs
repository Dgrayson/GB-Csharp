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

        public CPU(MMU mmu)
        {
            this._mmu = mmu; 
        }

        public void execute()
        {
            byte opcode = _mmu.ReadByte(PC);

            switch (opcode)
            {
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

                case  
                default: { break; } 
            }
        }

        public void LoadRegister() { }
        public void LoadRegisterImmediate() { }
    }
}
