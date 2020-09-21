using BO.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.MinLength(5, ErrorMessage = "Non")]
        [System.ComponentModel.DataAnnotations.MaxLength(20)]
        [Uniquorum]
        public string Nom { get; set; }
        public Pate Pate { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

       
    }
}
