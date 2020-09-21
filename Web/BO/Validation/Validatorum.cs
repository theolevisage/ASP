using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Validatorum : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            bool result = false;
            if (value != null && (value as List<int>).Count() > 1 && (value as List<int>).Count() < 6)
            {
                result = true;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Tu fais dla marde osti ! Mets dla bouffe dans ta pizz !";
        }
    }
}