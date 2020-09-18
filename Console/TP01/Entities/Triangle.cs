using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Entities
{
    class Triangle : Forme
    {
        private int a;
        private int b;
        private int c;

        public Triangle()
        {

        }

        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }

        public override double Perimetre => a+b+c;

        public override double Aire
        {
            get { return Math.Sqrt(this.Perimetre/2*(this.Perimetre / 2 - a) *(this.Perimetre / 2 - b) *(this.Perimetre / 2 - c)); }
        }
    }
}
