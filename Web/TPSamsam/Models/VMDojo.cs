using Entity_Samourai;
using System.Collections.Generic;

namespace TPSamsam.Models
{
    public class VMDojo
    {
        public Samourai Samourai { get; set; }
        public Arme Arme { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdArme { get; set; }
    }
}