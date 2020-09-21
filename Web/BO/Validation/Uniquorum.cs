using Entity_Pizz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPModule3.Database;

namespace Entity_Pizz.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Uniquorum : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            bool result = true;
            List<string> noms = mesPizz().Select(x => x.Nom).ToList();
            if (mesPizz() != null && mesPizz().Count > 0 && value != null && noms.Contains(value))
            {
                result = false;
            }

            return result;
        }

        private List<Pizza> mesPizz()
        {
            return FakeDb.Instance.ListePizzas;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Tu fais dla marde osti ! Choisi z'y un nom ben nice !";
        }
    }
}