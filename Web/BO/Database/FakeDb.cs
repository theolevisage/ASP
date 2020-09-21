using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule3.Database
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

        private FakeDb()
        {
            init();
        }

        public List<Pizza> ListePizzas { get; private set; } = new List<Pizza>();
        public List<Ingredient> ListeIngredientsDispo { get; private set; }
        public List<Pate> ListePatesDispo { get; private set; }

        public void init()
        {
           this.ListeIngredientsDispo = new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
        };

            this.ListePatesDispo = new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
        };

        }
       
    }
}
