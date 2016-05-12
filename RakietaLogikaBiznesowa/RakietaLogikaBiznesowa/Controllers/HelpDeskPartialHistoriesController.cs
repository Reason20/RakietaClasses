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
    public class HelpDeskPartialHistoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: HelpDeskPartialHistories
        public async Task<ActionResult> Index()
        {
            var helpDeskPartialHistory = db.HelpDeskPartialHistory.Include(h => h.HelpdeskApplication).Include(h => h.Recipient).Include(h => h.Worker);
            return View(await helpDeskPartialHistory.ToListAsync());
        }

        // GET: HelpDeskPartialHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpDeskPartialHistory helpDeskPartialHistory = await db.HelpDeskPartialHistory.FindAsync(id);
            if (helpDeskPartialHistory == null)
            {
                return HttpNotFound();
            }
            return View(helpDeskPartialHistory);
        }

        // GET: HelpDeskPartialHistories/Create
        public ActionResult Create()
        {
            ViewBag.HelpdeskId = new SelectList(db.HelpdeskSets, "Id", "Title");
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName");
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: HelpDeskPartialHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Status,AnswerDate,AnswerText,HelpdeskId,WorkerId,RecipientId")] HelpDeskPartialHistory helpDeskPartialHistory)
        {
            if (ModelState.IsValid)
            {
                db.HelpDeskPartialHistory.Add(helpDeskPartialHistory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HelpdeskId = new SelectList(db.HelpdeskSets, "Id", "Title", helpDeskPartialHistory.HelpdeskId);
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.WorkerId);
            return View(helpDeskPartialHistory);
        }

        // GET: HelpDeskPartialHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpDeskPartialHistory helpDeskPartialHistory = await db.HelpDeskPartialHistory.FindAsync(id);
            if (helpDeskPartialHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.HelpdeskId = new SelectList(db.HelpdeskSets, "Id", "Title", helpDeskPartialHistory.HelpdeskId);
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.WorkerId);
            return View(helpDeskPartialHistory);
        }

        // POST: HelpDeskPartialHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Status,AnswerDate,AnswerText,HelpdeskId,WorkerId,RecipientId")] HelpDeskPartialHistory helpDeskPartialHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helpDeskPartialHistory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HelpdeskId = new SelectList(db.HelpdeskSets, "Id", "Title", helpDeskPartialHistory.HelpdeskId);
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpDeskPartialHistory.WorkerId);
            return View(helpDeskPartialHistory);
        }

        // GET: HelpDeskPartialHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpDeskPartialHistory helpDeskPartialHistory = await db.HelpDeskPartialHistory.FindAsync(id);
            if (helpDeskPartialHistory == null)
            {
                return HttpNotFound();
            }
            return View(helpDeskPartialHistory);
        }

        // POST: HelpDeskPartialHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HelpDeskPartialHistory helpDeskPartialHistory = await db.HelpDeskPartialHistory.FindAsync(id);
            db.HelpDeskPartialHistory.Remove(helpDeskPartialHistory);
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
