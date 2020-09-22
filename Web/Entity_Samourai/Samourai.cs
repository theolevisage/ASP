using System.Collections.Generic;
namespace Entity_Samourai
{
    public class Samourai : Ideable
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        [Unikashi]
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartials { get; set; }
    }
}
