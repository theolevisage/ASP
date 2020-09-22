using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TPModule3.Database;

namespace Entity_Pizz.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Recetorum : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            bool result = true;
            if (value is List<int>)
            {
                var maList = value as List<int>;

                if (FakeDb.Instance.ListePizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                {
                    result = false;
                }
            }

            return result;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;
                var vm = validationContext.ObjectInstance as VMPizz;
                if (vm.Pizza != null && vm.Pizza.Id != 0)
                {
                    if (FakeDb.Instance.ListePizzas.Where(x => x.Id != vm.Pizza.Id).Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                }
                else
                {
                    if (FakeDb.Instance.ListePizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                }
            }

            if (result == false)
            {
                return new ValidationResult("Ces ingredients sont déjà utilisés");
            }
            else
            {
                return null;
            }
        }

        private List<Pizza> mesPizz()
        {
            return FakeDb.Instance.ListePizzas;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Tu fais dla marde osti ! Soit créatif bordel de dieu !";
        }
    }
}