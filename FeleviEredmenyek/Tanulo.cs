using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeleviEredmenyek
{
    class Tanulo
    {
        public string Neve { get; set; }
        public long Azonosito { get; set; }
        public Dictionary<string, List<int>> Jegyek { get; set; }

        //public double Atlag => 

        public Tanulo(string sor, List<string> tantargyak)
        {
            var v = sor.Split(' ');
            this.Neve = v[0];
            this.Azonosito = long.Parse(v[1]);
            this.Jegyek = new Dictionary<string, List<int>>();
            for (int i = 2; i < v.Length; i += 2)
            {
                string tantargy = tantargyak[i - 2];
                int jegy = int.Parse(v[i]);

                if (!Jegyek.ContainsKey(tantargy))
                {
                    Jegyek[tantargy] = new List<int>();
                }

                Jegyek[tantargy].Add(jegy);
            }
        }

        public override string ToString()
        {
            return $"{this.Neve}, {this.Azonosito}, {this.Jegyek}";
        }

    }
}
