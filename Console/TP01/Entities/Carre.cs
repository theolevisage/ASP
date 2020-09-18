using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Entities
{
    class Carre : Forme
    {
        private int longueur;

        public Carre()
        {
                
        }

        public int Longueur { get => longueur; set => longueur = value; }

        public override double Perimetre => 4 * longueur;

        public override double Aire
        {
            get { return Math.Pow(longueur, 2); }
        }
    }
}
