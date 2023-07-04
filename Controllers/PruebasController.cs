using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class PruebasController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Pruebas
        public ActionResult Index()
        {
            return View(db.Prueba.ToList());
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // GET: Pruebas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pruebas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Descripcion")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                /*
                var comprobar = db.Prueba.First();
                Nullable<int> identificador = null;
                if (comprobar != null) identificador = comprobar.Id++;
                else identificador = 0;

                prueba.Id = (int)identificador;

                Prueba registro = new Prueba()
                {
                    Id = (int)identificador,
                    Nombre = prueba.Nombre,
                    Descripcion = prueba.Descripcion,
                };

                db.Entry(registro).State = EntityState.Detached;
                */
                var comprobar = db.Prueba.Find(prueba.Id);
                if (comprobar != null)
                {
                    prueba.Id = db.Prueba.Max(u => u.Id) +1;

                }
                db.Prueba.Add(prueba);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prueba);
        }

        // GET: Pruebas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prueba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prueba);
        }

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Prueba.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prueba prueba = db.Prueba.Find(id);
            db.Prueba.Remove(prueba);
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
