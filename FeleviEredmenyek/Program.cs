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
        static Tanulo F3Harmasos(List<Tanulo> a)
        {
            return a.First(d => d.Jegyek["Angol nyelv"] == 3);
        }
        static int F4LegjobbJegy(List<Tanulo> a)
        {
            var legjobbJegy = a.SelectMany(tanulo => tanulo.Jegyek.Values).Max();

            return legjobbJegy;
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
                    var sor = sr.ReadLine();
                    if (i % 2 == 0)
                    {
                        adatok.Add(new Tanulo(sor, tantargyNevek));
                    }
                }

                Console.WriteLine($"1. feladat \nAz osztály átlaga: {Math.Round(F1OsszAt(adatok), 2)}");
                foreach (var i in F1TantargyAt(adatok))
                {
                    Console.WriteLine($"{i.Key}: {Math.Round(i.Value, 2)}");
                }

                Console.WriteLine("2. feladat");
                var bukottak = adatok.Where(d => d.Jegyek["Programozás gyakorlat"] == 1).Select(d => d.Neve).ToList();
                Console.WriteLine("Programozás gyakorlatból bukott diákok nevei:");
                foreach (var i in bukottak)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("3. feladat");
                var harmasos = F3Harmasos(adatok);
                if (harmasos != null)
                {
                    Console.WriteLine(harmasos);
                }

                Console.WriteLine("4. feladat");
                Console.WriteLine("Melyik tanuló legjobb jegyét szeretnéd? ");
                var keresettTanulo = Console.ReadLine();

                if (keresettTanulo == null)
                {
                    Console.WriteLine("Hiba nem lehet üres");
                }
                else if (!adatok.Any(d => d.Neve == keresettTanulo))
                {
                    Console.WriteLine("Hiba: A megadott tanuló nem található.");
                }
                else
                {
                    Console.WriteLine(F4LegjobbJegy(adatok));
                    //5. feladat
                    using (var sw = new StreamWriter(@"..\..\..\src\4.feladat.txt"))
                    {
                        var f5Nev = adatok.FirstOrDefault(d => d.Neve == keresettTanulo);
                        sw.WriteLine($"{f5Nev.Neve},\t{f5Nev.Azonosito}");
                    }
                }

            }
        }
    }
}
