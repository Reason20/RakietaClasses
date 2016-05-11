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
    public class RoomsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Rooms
        public async Task<ActionResult> Index()
        {
            var rooms = db.Rooms.Include(r => r.Club).Include(r => r.Editor);
            return View(await rooms.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = await db.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            db.Entry(rooms).Reference(e => e.Club).Load();
            db.Entry(rooms).Reference(e => e.Editor).Load();
            return View(rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name");
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,MaxPeople,ClubId,TypeOf,LastEditTime,LastEditor")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                rooms.LastEditor = 52;
                rooms.LastEditTime = DateTime.Now;
                db.Rooms.Add(rooms);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", rooms.ClubId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", rooms.LastEditor);
            return View(rooms);
        }

        // GET: Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = await db.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", rooms.ClubId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", rooms.LastEditor);
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,MaxPeople,ClubId,TypeOf,LastEditTime,LastEditor")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                rooms.LastEditor = 52;
                rooms.LastEditTime = DateTime.Now;
                db.Entry(rooms).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", rooms.ClubId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", rooms.LastEditor);
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = await db.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            db.Entry(rooms).Reference(e => e.Club).Load();
            db.Entry(rooms).Reference(e => e.Editor).Load();
            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rooms rooms = await db.Rooms.FindAsync(id);
            db.Rooms.Remove(rooms);
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
