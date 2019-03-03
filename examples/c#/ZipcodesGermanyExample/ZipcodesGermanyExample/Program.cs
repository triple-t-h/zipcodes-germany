using System;

namespace ZipcodesGermanyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ZipcodesGermany.GetPlaces("19386"));
            Console.WriteLine(ZipcodesGermany.GetPostcodes("Berlin"));
            Console.ReadKey();
        }
    }
}
