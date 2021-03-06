﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPSamsam.Data
{
    public class TPSamsamContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TPSamsamContext() : base("name=TPSamsamContext")
        {
        }

        public System.Data.Entity.DbSet<Entity_Samourai.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<Entity_Samourai.Arme> Armes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity_Samourai.Samourai>().HasOptional(x => x.Arme);
            modelBuilder.Entity<Entity_Samourai.Samourai>().HasMany(x => x.ArtMartials).WithMany();
        }

        public System.Data.Entity.DbSet<Entity_Samourai.ArtMartial> ArtMartials { get; set; }
    }
}
