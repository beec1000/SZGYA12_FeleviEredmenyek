using System;
using System.Collections.Generic;
using System.IO;

namespace FeleviEredmenyek
{
    class Program
    {
        static void Main(string[] args)
        {
            var jegyek = new List<Tanulo>();

            using var sr = new StreamReader(@"..\..\..\src\Adatok.txt");
            {
                _ = sr.ReadLine();

            }

        }
    }
}
