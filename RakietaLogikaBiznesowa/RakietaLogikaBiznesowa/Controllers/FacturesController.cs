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
    public class FacturesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Factures
        public async Task<ActionResult> Index()
        {
            var facture = db.Facture.Include(f => f.Club).Include(f => f.Contractor).Include(f => f.Editor).Include(f => f.UserCreate);
            return View(await facture.ToListAsync());
        }

        // GET: Factures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name");
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OpDate,FactureNumber,NumberSeries,CrDate,Category,ContractorId,CreatorId,LastEditTime,LastEditor,InstallmentCount,Value,IsPaid,ClubId")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Facture.Add(facture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OpDate,FactureNumber,NumberSeries,CrDate,Category,ContractorId,CreatorId,LastEditTime,LastEditor,InstallmentCount,Value,IsPaid,ClubId")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Facture facture = await db.Facture.FindAsync(id);
            db.Facture.Remove(facture);
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
