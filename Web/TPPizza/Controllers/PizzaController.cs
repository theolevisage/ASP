using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule3.Database;
using TPPizza.Models;

namespace TPPizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            if (FakeDb.Instance.ListePizzas.Count == 0)
            {
                return RedirectToAction("Create");
            }
            return View(FakeDb.Instance.ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var fdb = FakeDb.Instance;
            var item = fdb.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            VMPizz vm = initVM();
            return View(vm);
        }

        private VMPizz initVM()
        {
            var fdb = FakeDb.Instance;
            VMPizz vm = new VMPizz();
            vm.Pates = fdb.ListePatesDispo;
            vm.Ingredients = fdb.ListeIngredientsDispo;
            return vm;
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(VMPizz vm)
        {
            try
            {
                var fdb = FakeDb.Instance;
                vm.Pizza.Pate = fdb.ListePatesDispo.FirstOrDefault(x => x.Id == vm.IdPate);
                foreach (int ingredient in vm.IdsIngedients)
                {
                    vm.Pizza.Ingredients.Add(fdb.ListeIngredientsDispo.FirstOrDefault(x => x.Id == ingredient));
                }
                vm.Pizza.Id =fdb.ListePizzas.Count == 0 ? 1 : fdb.ListePizzas.Max(x => x.Id) + 1; ;
                fdb.ListePizzas.Add(vm.Pizza);
                

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                var fdb = FakeDb.Instance;
                vm.Pates = fdb.ListePatesDispo;
                vm.Ingredients = fdb.ListeIngredientsDispo;
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var fdb = FakeDb.Instance;
            var item = fdb.ListePizzas.FirstOrDefault(x => x.Id == id);
            VMPizz vm = initVM();
            vm.Pizza = item;
            vm.IdPate = item.Pate.Id;
            vm.IdsIngedients = item.Ingredients.Select(x => x.Id).ToList();
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(VMPizz vm)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDb.Instance.ListePatesDispo.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDb.Instance.ListeIngredientsDispo.Where(x => vm.IdsIngedients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var fdb = FakeDb.Instance;
            var item = fdb.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var fdb = FakeDb.Instance;
                var item = fdb.ListePizzas.FirstOrDefault(x => x.Id == id);
                if(item != null)
                {
                    fdb.ListePizzas.Remove(item);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
