﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TPSamsam.Data;
using TPSamsam.Models;

namespace Entity_Samourai.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Unikashi : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Cette arme possède déjà un maitre";
        }

        //public override bool IsValid(object value)
        //{
        //    var result = true;
        //    int? arme = value as int?;
        //    using (var db = new TPSamsamContext())
        //    {
        //        var equiped = db.Samourais.Where(x => x.Arme.Id == arme).ToList().Count();
        //       if (equiped > 0)
        //        {
        //            result = false;
        //        }
        //    }
            
        //    return result;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = true;
            int? arme = value as int?;
            var infos = validationContext.ObjectInstance as VMDojo;
            using (var db = new TPSamsamContext())
            {

                var equiped = db.Samourais.Where(x => x.Arme.Id == arme).ToList().Count();
                if (infos.IdArme != arme && equiped > 0)
                {
                    result = false;
                }
            }
            if (result)
            {
                return null;
            }
            return new ValidationResult("Pas content");
        }
    }
}