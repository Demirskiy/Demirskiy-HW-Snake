using System;
using System.Threading;
using System.Collections.Generic;
namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = new List<int>();
            
            int x=0;

            while (x < 4)
            {
                length.Add(x);
                x++;
            }
            for (var index = 0; index < length.Count; index++)
            {
                Console.WriteLine(length[index]);
            }
        }
    }
}
