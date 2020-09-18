using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Entities
{
    class Cercle : Forme
    {
        private int rayon;

        public Cercle()
        {
              
        }

        public int Rayon
        {
            get { return rayon; }
            set { rayon = value; }
        }



        public override double Perimetre => 2 * Math.PI * rayon;

        public override double Aire
        {
            get { return Math.PI*Math.Pow(rayon, 2); }
        }

    }
}
