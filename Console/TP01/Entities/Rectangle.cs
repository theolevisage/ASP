using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Entities
{
    class Rectangle : Forme
    {
        public int largeur;
        public int longueur;

        public int Largeur { get => largeur; set => largeur = value; }
        public int Longueur { get => longueur; set => longueur = value; }

        public Rectangle()
        {
                
        }

        public override double Perimetre => 2 * (largeur+ longueur) ;

        public override double Aire
        {
            get { return largeur*longueur; }
        }
    }
}
