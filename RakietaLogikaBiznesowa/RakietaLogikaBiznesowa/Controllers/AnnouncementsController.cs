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
    public class AnnouncementsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Announcements
        public async Task<ActionResult> Index()
        {
            var announcements = db.Announcements.Include(a => a.Editor).Include(a => a.Tag);
            return View(await announcements.ToListAsync());
        }

        // GET: Announcements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,CreateTime,Text,Note,IsActive,LastEditTime,TagId,LastEditor")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", announcement.LastEditor);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", announcement.TagId);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", announcement.LastEditor);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", announcement.TagId);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,CreateTime,Text,Note,IsActive,LastEditTime,TagId,LastEditor")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", announcement.LastEditor);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", announcement.TagId);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Announcement announcement = await db.Announcements.FindAsync(id);
            db.Announcements.Remove(announcement);
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
