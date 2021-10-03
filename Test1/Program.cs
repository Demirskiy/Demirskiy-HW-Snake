using System;
using System.Threading;
namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {    char input = default;
            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine("P");
                input = (char)Console.Read();
            }
        }
    }
}
