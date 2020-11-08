using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestión_de_las_Finanzas_Personales;

namespace Gestión_de_las_Finanzas_Personales.Controllers
{
    public class UsuariosController : Controller
    {
        private Sistema_de__Finanzas_PersonalesEntities db = new Sistema_de__Finanzas_PersonalesEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Gestión_de_Egresos).Include(u => u.Gestion_de_Ingresos);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuarios = new SelectList(db.Gestión_de_Egresos, "IdGestion_de_Egresos", "Tipos_de_Egresos");
            ViewBag.IdUsuarios = new SelectList(db.Gestion_de_Ingresos, "IdGestion_de_Ingresos", "Tipos_de_ingresos");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuarios,Nombre,Cedula,Limite_Egresos,Tipo_Persona,Fecha_Corte,Estado")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuarios = new SelectList(db.Gestión_de_Egresos, "IdGestion_de_Egresos", "Tipos_de_Egresos", usuarios.IdUsuarios);
            ViewBag.IdUsuarios = new SelectList(db.Gestion_de_Ingresos, "IdGestion_de_Ingresos", "Tipos_de_ingresos", usuarios.IdUsuarios);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuarios = new SelectList(db.Gestión_de_Egresos, "IdGestion_de_Egresos", "Tipos_de_Egresos", usuarios.IdUsuarios);
            ViewBag.IdUsuarios = new SelectList(db.Gestion_de_Ingresos, "IdGestion_de_Ingresos", "Tipos_de_ingresos", usuarios.IdUsuarios);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuarios,Nombre,Cedula,Limite_Egresos,Tipo_Persona,Fecha_Corte,Estado")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuarios = new SelectList(db.Gestión_de_Egresos, "IdGestion_de_Egresos", "Tipos_de_Egresos", usuarios.IdUsuarios);
            ViewBag.IdUsuarios = new SelectList(db.Gestion_de_Ingresos, "IdGestion_de_Ingresos", "Tipos_de_ingresos", usuarios.IdUsuarios);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
