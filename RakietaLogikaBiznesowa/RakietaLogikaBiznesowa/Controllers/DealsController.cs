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
    public class DealsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Deals
        public async Task<ActionResult> Index()
        {
            var deal = db.Deal.Include(d => d.Contractor).Include(d => d.DealCreator).Include(d => d.DealMenager).Include(d => d.Editor).Include(d => d.User);
            return View(await deal.ToListAsync());
        }

        // GET: Deals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = await db.Deal.FindAsync(id);

            db.Entry(deal).Reference(e => e.DealMenager).Load();
            db.Entry(deal).Reference(e => e.User).Load();
            db.Entry(deal).Reference(e => e.DealCreator).Load();
            db.Entry(deal).Reference(e => e.Contractor).Load();
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // GET: Deals/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login");
            ViewBag.MenagerId = new SelectList(db.User, "Id", "Login");
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login");
            ViewBag.UserId = new SelectList(db.User, "Id", "Login");
            return View();
        }

        // POST: Deals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,CurrentStage,ClosingStage,Note,EndDate,CreateDate,LastEditTime,UserId,ContractorId,CreatorId,MenagerId,LastEditor")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Deal.Add(deal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", deal.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", deal.CreatorId);
            ViewBag.MenagerId = new SelectList(db.User, "Id", "Login", deal.MenagerId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", deal.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", deal.UserId);
            return View(deal);
        }

        // GET: Deals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = await db.Deal.FindAsync(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", deal.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", deal.CreatorId);
            ViewBag.MenagerId = new SelectList(db.User, "Id", "Login", deal.MenagerId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", deal.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", deal.UserId);
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,CurrentStage,ClosingStage,Note,EndDate,CreateDate,LastEditTime,UserId,ContractorId,CreatorId,MenagerId,LastEditor")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", deal.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", deal.CreatorId);
            ViewBag.MenagerId = new SelectList(db.User, "Id", "Login", deal.MenagerId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", deal.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", deal.UserId);
            return View(deal);
        }

        // GET: Deals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = await db.Deal.FindAsync(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Deal deal = await db.Deal.FindAsync(id);
            db.Deal.Remove(deal);
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
