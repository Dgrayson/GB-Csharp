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
                
            }

        }
    }
}
