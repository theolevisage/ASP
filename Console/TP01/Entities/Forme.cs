using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Entities
{
    public abstract class Forme : IGeo
    {

        public Forme()
        {

        }

        public virtual double Aire { get; set; }

        public virtual double Perimetre { get; set; }

        public string Show()
        {
            return String.Format("Aire : {0}\nPérimetre : {1}", this.Aire, this.Perimetre);
        }

        public override string ToString()
        {
            return this.Show();
        }
    }
}
