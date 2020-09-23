using Entity_Samourai.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entity_Samourai
{
    public class Samourai : Ideable
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [Display(Name = "Arts martiaux maitrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        public int Potentiel
        {
            get { if (this.Arme!=null)
                {
                    return (this.Force + this.Arme.Degats) * (this.ArtMartials.Count() + 1);
                }
                else
                {
                    return 0;
                }
                     }
        }

    }
}
