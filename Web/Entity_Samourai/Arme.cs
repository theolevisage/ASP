using Entity_Samourai.Validation;
using System.ComponentModel.DataAnnotations;

namespace Entity_Samourai
{
    public class Arme : Ideable
    {
        public string Nom { get; set; }
        [Display(Name = "Dégats")]
        public int Degats { get; set; }
    }
}