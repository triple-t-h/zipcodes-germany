using System;

namespace ZipcodesGermanyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ZipcodesGermany.GetPlaces("73434"));
            Console.WriteLine(ZipcodesGermany.GetPostcodes("Aachen"));
            Console.ReadKey();
        }
    }
}
