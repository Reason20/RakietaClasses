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
            //ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName");
            //ViewBag.WorkerId = new SelectList(db.User.Where(e=>e.IsWorker==true), "Id", "Login");
            return View();
        }

        // POST: Helpdesks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TypeOf,Title,Text")] Helpdesk helpdesk)
        {
            if (ModelState.IsValid)
            {
                helpdesk.Date = DateTime.Now;
                helpdesk.isAnswered = false;
                helpdesk.RecipientId = 52;
                helpdesk.Status = HelpdeskStatus.Zgłoszone;
                db.HelpdeskSets.Add(helpdesk);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.RecipientId = new SelectList(db.User, "Id", "FirstName", helpdesk.RecipientId);
            //ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", helpdesk.WorkerId);
            return View(helpdesk);
        }

        // GET: Helpdesks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helpdesk oldhelpdesk = await db.HelpdeskSets.FindAsync(id);
            if (oldhelpdesk == null)
            {
                return HttpNotFound();
            }
            Helpdesk newhelpdesk = new Helpdesk()
            {
                Id=oldhelpdesk.Id,
                Status=oldhelpdesk.Status,
                TypeOf=oldhelpdesk.TypeOf,
                Title=oldhelpdesk.Title,
                Text=oldhelpdesk.Text,
                Date=oldhelpdesk.Date,
                RecipientId=oldhelpdesk.RecipientId
            };
            Models.HelpDesk.OldAndNewAnswer helpdesk = new Models.HelpDesk.OldAndNewAnswer()
            {
                OldAnswer=oldhelpdesk,
                NewAnswer=newhelpdesk
            };
            //ViewBag.RecipientId = new SelectList(db.User, "Id", "Login", helpdesk.OldAnswer.RecipientId);
            //ViewBag.WorkerId = new SelectList(db.User, "Id", "Login", helpdesk.OldAnswer.WorkerId);
            return View(helpdesk);
        }

        // POST: Helpdesks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OldAnswer,NewAnswer")] Models.HelpDesk.OldAndNewAnswer helpdesk)
        {
            if (ModelState.IsValid)
            {
                if (helpdesk.OldAnswer.AnswerDate.HasValue)
                {
                    HelpDeskPartialHistory oldanswer = new HelpDeskPartialHistory()
                    {
                        Status=helpdesk.OldAnswer.Status,
                        AnswerDate=helpdesk.OldAnswer.AnswerDate.Value,
                        AnswerText=helpdesk.OldAnswer.AnswerText,
                        HelpdeskId=helpdesk.OldAnswer.Id,
                        RecipientId=helpdesk.OldAnswer.RecipientId,
                        WorkerId=helpdesk.OldAnswer.WorkerId
                    };
                    db.HelpDeskPartialHistory.Add(oldanswer);
                    await db.SaveChangesAsync();
                }
                helpdesk.NewAnswer.AnswerDate = DateTime.Now;
                db.Entry(helpdesk.NewAnswer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.RecipientId = new SelectList(db.User, "Id", "Login", helpdesk.OldAnswer.RecipientId);
            //ViewBag.WorkerId = new SelectList(db.User, "Id", "Login", helpdesk.OldAnswer.WorkerId);
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
