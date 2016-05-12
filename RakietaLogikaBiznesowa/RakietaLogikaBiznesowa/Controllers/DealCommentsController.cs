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
    public class DealCommentsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DealComments
        public async Task<ActionResult> Index()
        {
            var dealComments = db.DealComments.Include(d => d.Creator).Include(d => d.Deal);
            return View(await dealComments.ToListAsync());
        }

        // GET: DealComments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealComment dealComment = await db.DealComments.FindAsync(id);
            if (dealComment == null)
            {
                return HttpNotFound();
            }
            return View(dealComment);
        }

        // GET: DealComments/Create
        public ActionResult Create()
        {
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login");
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title");
            return View();
        }

        // POST: DealComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,Text,DealId,CreatorId")] DealComment dealComment)
        {
            if (ModelState.IsValid)
            {
                db.DealComments.Add(dealComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealComment.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealComment.DealId);
            return View(dealComment);
        }

        // GET: DealComments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealComment dealComment = await db.DealComments.FindAsync(id);
            if (dealComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealComment.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealComment.DealId);
            return View(dealComment);
        }

        // POST: DealComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,Text,DealId,CreatorId")] DealComment dealComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealComment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealComment.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealComment.DealId);
            return View(dealComment);
        }

        // GET: DealComments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealComment dealComment = await db.DealComments.FindAsync(id);
            if (dealComment == null)
            {
                return HttpNotFound();
            }
            return View(dealComment);
        }

        // POST: DealComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DealComment dealComment = await db.DealComments.FindAsync(id);
            db.DealComments.Remove(dealComment);
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
