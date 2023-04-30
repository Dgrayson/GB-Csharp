using System;
using System.Collections.Generic;
using System.Text;

namespace Gameboy_Emulator
{
    class MMU
    {

        private byte[] memory; 

        public MMU()
        {
            memory = new byte[0xFFFF];
        }
        public void WriteByte(ushort addr, byte value) { memory[addr] = value; }
        public byte ReadByte(ushort addr) { return memory[addr]; }
    }

    

}
