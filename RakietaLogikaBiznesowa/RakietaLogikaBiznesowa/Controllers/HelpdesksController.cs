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
    public class HelpdesksController : Controller
    {
        private Model1 db = new Model1();

        // GET: Helpdesks
        public async Task<ActionResult> Index()
        {
            var helpdeskSets = db.HelpdeskSets.Include(h => h.Recipient).Include(h => h.Worker);
            return View(await helpdeskSets.ToListAsync());
        }

        // GET: Helpdesks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helpdesk helpdesk = await db.HelpdeskSets.FindAsync(id);
            if (helpdesk == null)
            {
                return HttpNotFound();
            }
            return View(helpdesk);
        }

        // GET: Helpdesks/Create
        public ActionResult Create()
        {
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName");
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Helpdesks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Status,TypeOf,Title,Text,Date,isAnswered,AnswerDate,AnswerText,RecipientId,WorkerId")] Helpdesk helpdesk)
        {
            if (ModelState.IsValid)
            {
                db.HelpdeskSets.Add(helpdesk);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpdesk.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpdesk.WorkerId);
            return View(helpdesk);
        }

        // GET: Helpdesks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helpdesk helpdesk = await db.HelpdeskSets.FindAsync(id);
            if (helpdesk == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpdesk.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpdesk.WorkerId);
            return View(helpdesk);
        }

        // POST: Helpdesks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Status,TypeOf,Title,Text,Date,isAnswered,AnswerDate,AnswerText,RecipientId,WorkerId")] Helpdesk helpdesk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helpdesk).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpdesk.RecipientId);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpdesk.WorkerId);
            return View(helpdesk);
        }

        // GET: Helpdesks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helpdesk helpdesk = await db.HelpdeskSets.FindAsync(id);
            if (helpdesk == null)
            {
                return HttpNotFound();
            }
            return View(helpdesk);
        }

        // POST: Helpdesks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Helpdesk helpdesk = await db.HelpdeskSets.FindAsync(id);
            db.HelpdeskSets.Remove(helpdesk);
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
