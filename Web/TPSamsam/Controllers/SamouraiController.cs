using Entity_Samourai;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TPSamsam.Data;
using TPSamsam.Models;

namespace TPSamsam.Controllers
{
    public class SamouraiController : Controller
    {
        private TPSamsamContext db = new TPSamsamContext();

        private void InitList(VMDojo vm)
        {
            var armesUsed = db.Samourais.Select(x => x.Arme.Id).ToList();
            vm.Armes = db.Armes.Where(x => !armesUsed.Any(y => y == x.Id)).ToList();
            if (vm.Samourai != null)
            {
                    var armeEquiped = db.Armes.First(x => vm.IdArme != null && x.Id == vm.IdArme);
                    if (armeEquiped != null)
                    {
                        vm.Armes.Add(armeEquiped);
                    }
                
            }
            vm.ArtMartials = db.ArtMartials.ToList();
        }
        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            VMDojo vm = new VMDojo();
            InitList(vm);
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMDojo vm)
        {
            if (ModelState.IsValid)
            {
                vm.Samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdArme);
                foreach(var item in vm.IdArtMArtials)
                {
                    vm.Samourai.ArtMartials.Add(db.ArtMartials.FirstOrDefault(x => x.Id == item));
                }
                Samourai samourai = vm.Samourai;
                db.Samourais.Add(samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            InitList(vm);
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMDojo vm = new VMDojo();
            Samourai samourai = db.Samourais.Find(id);
            vm.Samourai = samourai;
            if(vm.Samourai.Arme != null)
            {
                vm.IdArme = vm.Samourai.Arme.Id;
            }
            if (vm.Samourai.ArtMartials != null)
            {
                vm.IdArtMArtials = samourai.ArtMartials.Select(x => x.Id).ToList();
            }
            InitList(vm);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMDojo vm)
        {
            if (ModelState.IsValid)
            {
                Samourai sam = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == vm.Samourai.Id);
                sam.Force = vm.Samourai.Force;
                sam.Nom = vm.Samourai.Nom;
                Arme arme = db.Armes.Find(vm.IdArme);
                foreach (var item in vm.IdArtMArtials)
                {
                    vm.Samourai.ArtMartials.Add(db.ArtMartials.FirstOrDefault(x => x.Id == item));
                }
                sam.ArtMartials = vm.Samourai.ArtMartials;
                sam.Arme = arme;
                db.Entry(sam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            InitList(vm);
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
