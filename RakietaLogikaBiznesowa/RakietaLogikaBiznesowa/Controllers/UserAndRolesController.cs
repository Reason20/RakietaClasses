using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExpress.Utils;
using RakietaLogikaBiznesowa.Models;

namespace RakietaLogikaBiznesowa.Controllers
{
    public class UserAndRolesController : Controller
    {
        private Model1 db = new Model1();

        // GET: UserAndRoles
        public async Task<ActionResult> Index()
        {
            var userAndRoles = db.UserAndRoles.Include(u => u.Role).Include(u => u.User);
            return View(await userAndRoles.ToListAsync());
        }

        // GET: UserAndRoles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAndRole userAndRole = await db.UserAndRoles.FindAsync(id);
            if (userAndRole == null)
            {
                return HttpNotFound();
            }
            return View(userAndRole);
        }

        // GET: UserAndRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "Login");
            ViewBag.LastEditTime = DateTime.Now;
            return View();
        }

        // POST: UserAndRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,RoleId")] UserAndRole userAndRole)
        {
            if (ModelState.IsValid)
            {
                db.UserAndRoles.Add(userAndRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", userAndRole.RoleId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", userAndRole.UserId);
            return View(userAndRole);
        }

        // GET: UserAndRoles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAndRole userAndRole = await db.UserAndRoles.FindAsync(id);
            if (userAndRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", userAndRole.RoleId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", userAndRole.UserId);
            return View(userAndRole);
        }

        // POST: UserAndRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,RoleId")] UserAndRole userAndRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAndRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", userAndRole.RoleId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", userAndRole.UserId);
            return View(userAndRole);
        }

        // GET: UserAndRoles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAndRole userAndRole = await db.UserAndRoles.FindAsync(id);
            if (userAndRole == null)
            {
                return HttpNotFound();
            }
            return View(userAndRole);
        }

        // POST: UserAndRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserAndRole userAndRole = await db.UserAndRoles.FindAsync(id);
            db.UserAndRoles.Remove(userAndRole);
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
