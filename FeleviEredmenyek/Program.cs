using System;
using System.Collections.Generic;
using System.IO;

namespace FeleviEredmenyek
{
    class Program
    {
        static void Main(string[] args)
        { 
            var adatok = new List<Tanulo>();

            using var sr = new StreamReader(@"..\..\..\src\Adatok.txt");

            string tantargy = sr.ReadLine();
            List<string> tantargyNevek = new List<string>(tantargy.Split('\t'));
            for (int i = 0; i < adatok.Count; i++)
            {
                adatok.Add(new Tanulo(sr.ReadLine(), tantargyNevek));
            }

            foreach (var i in adatok)
            {
                Console.WriteLine(i.ToString());
            }

        }
    }
}
