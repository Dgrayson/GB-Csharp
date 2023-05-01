using System;
using System.IO;

namespace Gameboy_Emulator
{
    class Program
    {
        const string fileName = "C:\\Users\\dgray\\Downloads\\BADAPPLE.GBC";
        static void Main(string[] args)
        {
            MMU mmu = new MMU(); 

            mmu.
            if(File.Exists(fileName))
            {
                ReadRom();
            }
            else
            {
                PrintMessage("File does not exist.");
            }
        }

        private static byte[] ReadRom()
        {
            byte[] dataArray = new byte[100000];

            PrintMessage("READING ROM"); 

            using FileStream fileStream = new FileStream(fileName, FileMode.Open);
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


             dataArray = File.ReadAllBytes(fileName); 
        }

        private static void PrintMessage(String message)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("*   {0}", message);
            Console.WriteLine("*******************");
        }
    }
}
