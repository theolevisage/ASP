using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TPSamsam.Data;

namespace Entity_Samourai.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Unikashi : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Cette arme possède déjà un maitre";
        }

        public override bool IsValid(object value)
        {
            using (var db = new TPSamsamContext())
            {

            }
            db.Armes.
            return base.IsValid(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}