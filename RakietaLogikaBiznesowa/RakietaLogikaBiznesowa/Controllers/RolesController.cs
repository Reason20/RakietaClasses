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
    public class RolesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            var role = db.Role.Include(r => r.Editor);
            return View(await role.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            db.Entry(role).Reference(e => e.Editor).Load();
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            ViewBag.Name = new SelectList(db.Permissions, "Name", "Name");
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Write,Read,Update,Delete,LastEditor,LastEditTime")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Role.Add(role);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", role.LastEditor);
            ViewBag.Name = new SelectList(db.Permissions, "Name", "Name", role.Name);
            ViewBag.LastEditTime = DateTime.Now;
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", role.LastEditor);
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Write,Read,Update,Delete,LastEditor,LastEditTime")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", role.LastEditor);
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            db.Entry(role).Reference(e => e.Editor).Load();
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Role role = await db.Role.FindAsync(id);
            db.Role.Remove(role);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Roles/AddRoleToUser
        public ActionResult AddRoleToUser()
        {
            ViewBag.UserId = new SelectList(db.User, "Id", "Login");
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name");
            return View();
        }
        // POST : Roles/AddRoleToUser/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRoleToUser([Bind(Include = "UserId,RoleId")] UserAndRole UserRoleViewBag)
        {
            if (ModelState.IsValid)
            {
                var user = db.User.First(e => e.Id == UserRoleViewBag.UserId);
                var role = db.Role.First(e => e.Id == UserRoleViewBag.RoleId);
                if (!user.Roles.Any(e => e.Equals(role)))
                    user.Roles.Add(role);
                

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.User, "Id", "Login", UserRoleViewBag.RoleId);
            ViewBag.Id = new SelectList(db.BankAccount, "Id", "Id", UserRoleViewBag.UserId);
            return View();
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
