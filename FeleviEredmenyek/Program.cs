using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FeleviEredmenyek
{
    class Program
    {
        static double F1OsszAt(List<Tanulo> a)
        {
            var x = a.Average(d => d.Atlag);
            return x;
        }
        static Dictionary<string, double> F1TantargyAt(List<Tanulo> a)
        {
            Dictionary<string, double> atlagok = new Dictionary<string, double>();
            foreach (var i in a.First().Jegyek.Keys)
            {
                atlagok[i] = a.Average(d => d.Jegyek[i]);
            }
            return atlagok;
        }

        static void Main(string[] args)
        { 
            var adatok = new List<Tanulo>();

            using var sr = new StreamReader(@"..\..\..\src\Adatok.txt");
            {
                string tantargy = sr.ReadLine();
                List<string> tantargyNevek = new List<string>(tantargy.Split('\t'));
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    if (i % 2 ==  0)
                    {   
                        adatok.Add(new Tanulo(sr.ReadLine(), tantargyNevek));
                    }
                }

                Console.WriteLine($"1. feladat \nAz osztály átlaga: {F1OsszAt(adatok)}");
                foreach (var i in F1TantargyAt(adatok))
                {
                    Console.WriteLine($"{i.Key}: {i.Value}");
                }

            }

        }
    }
}
