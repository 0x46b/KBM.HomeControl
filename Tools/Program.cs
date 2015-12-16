using System;
using System.Text;

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] input = new byte[]
            {
                0xB0,
                0x00,
                0x00,
                0xB5
            };
            Console.WriteLine($"{BitConverter.ToString(input)} = {Convert.ToBase64String(input)}");
            Console.ReadLine();
        }
    }
}
