using Entity_Samourai;
using Entity_Samourai.Validation;
using System.Collections.Generic;

namespace TPSamsam.Models
{
    public class VMDojo
    {
        public Samourai Samourai { get; set; }
        public Arme Arme { get; set; }
        public List<Arme> Armes { get; set; }
        [Unikashi]
        public int? IdArme { get; set; }
        public List<ArtMartial> ArtMartials { get; set; }
        public List<int?> IdArtMArtials { get; set; }
    }
}