using Entity_Pizz;
using Entity_Pizz.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Models
{
    public class VMPizz
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
        [Validatorum]
        [Recetorum]
        public List<int> IdsIngedients { get; set; }
        [Required]
        public int? IdPate { get; set; }
    }
}