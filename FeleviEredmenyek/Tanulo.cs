using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeleviEredmenyek
{
    class Tanulo
    {
        public string Neve { get; set; }
        public int Azonosito { get; set; }
        public Dictionary<string, int> Jegyek { get; set; }

        public Tanulo(string sor)
        {
            var v = sor.Split(' ');
            this.Neve = v[0];
            this.Azonosito = int.Parse(v[1]);
            for (int i = 2; i < v.Length; i += 2)
            {
                this.Jegyek[v[i]] = int.Parse(v[i + 1]);
            }
        }

        static void Atlag(int j)
        {
            var x = 
        }

    }
}
