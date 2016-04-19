using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RakietaLogikaBiznesowa.Models;

namespace RakietaLogikaBiznesowa.Controllers
{
    public class PermissionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Permissions
        public async Task<ActionResult> Index()
        {
            return View(await db.Permissions.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = await db.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permissions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(permissions);
        }

        // GET: Permissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = await db.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(permissions);
        }

        // GET: Permissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = await db.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Permissions permissions = await db.Permissions.FindAsync(id);
            db.Permissions.Remove(permissions);
            await db.SaveChangesAsync();
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
