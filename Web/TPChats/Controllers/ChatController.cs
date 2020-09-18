using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule3.Database;

namespace WebApplication1.Controllers
{
    public class ChatController : Controller
    {
        
        // GET: Chat
        public ActionResult Index()
        {
            
            return View(FakeDb.Instance.ListeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var item = FakeDb.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
          
            return View(item);
        }

        //// GET: Chat/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Chat/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Chat/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Chat/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var meuteDeChats = FakeDb.Instance.ListeChats;
            var item = meuteDeChats.FirstOrDefault(x => x.Id == id);
            meuteDeChats.Remove(item);

            return View(item);

        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
