﻿using BO;
using BO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPPizza.Models
{
    public class VMPizz
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
        [Validatorum]
        public List<int> IdsIngedients { get; set; }
        [Required]
        public int? IdPate { get; set; }
    }
}