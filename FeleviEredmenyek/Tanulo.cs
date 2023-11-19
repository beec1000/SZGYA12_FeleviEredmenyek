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
        public Dictionary<string, int> Jegyek { get; set; }
        public double Atlag => this.Jegyek.Values.Average();

        public Tanulo(string sor, List<string> tantargyak)
        {
            var v = sor.Split("\t");
            this.Neve = v[0];
            this.Azonosito = long.Parse(v[1]);
            this.Jegyek = new Dictionary<string, int>();
            for (int i = 2; i < v.Length; i++)
            {
                int jegy = int.Parse(v[i]);
                this.Jegyek[tantargyak[i]] = jegy;
            }
        }

        public override string ToString()
        {
            return $"{this.Neve}, {this.Azonosito}, {string.Join("; ", this.Jegyek)}";
        }
    }
}