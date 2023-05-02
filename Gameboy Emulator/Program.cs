using System;
using System.IO;

namespace Gameboy_Emulator
{
    class Program
    {
        const string fileName = "C:\\Users\\dgray\\OneDrive\\Desktop\\GB-Csharp\\Gameboy Emulator\\BADAPPLE.GBC";
        static void Main(string[] args)
        {
            MMU mmu = new MMU();
            CPU cpu; 

            if(File.Exists(fileName))
            {
                mmu.ReadRom(fileName);
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return; 
            }

            cpu = new CPU(mmu);

            bool running = true; 

            while(running)
            {
                cpu.execute(); 
            }
        }
    }
}
