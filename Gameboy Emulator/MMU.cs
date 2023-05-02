using System;
using System.Collections.Generic;
using System.IO;
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

        public void ReadRom(String fileName)
        {
            PrintMessage("READING ROM");
            memory = File.ReadAllBytes(fileName);


            /*using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            fileStream.Seek(0, SeekOrigin.Begin);

            Console.WriteLine("Filestream length is: {0}", fileStream.Length);

            int hexIn;
            String hex;

            for (int i = 0; i < fileStream.Length; i++)
            {
                hexIn = fileStream.ReadByte();
                hex = String.Format("{0:x2}", hexIn);

                Console.WriteLine(hex);
                System.Threading.Thread.Sleep(1000);


                
            }*/


        }

        private void PrintMessage(String message)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("*   {0}", message);
            Console.WriteLine("*******************");
        }
    }
}
