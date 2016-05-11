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
    public class DealActionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DealActions
        public async Task<ActionResult> Index()
        {
            var dealActions = db.DealActions.Include(d => d.Contractor).Include(d => d.Creator).Include(d => d.Deal).Include(d => d.Editor).Include(d => d.User);
            return View(await dealActions.ToListAsync());
        }

        // GET: DealActions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealActions dealActions = await db.DealActions.FindAsync(id);

            db.Entry(dealActions).Reference(e => e.Contractor).Load();
            db.Entry(dealActions).Reference(e => e.User).Load();
            db.Entry(dealActions).Reference(e => e.Creator).Load();
            db.Entry(dealActions).Reference(e => e.Editor).Load();
            db.Entry(dealActions).Reference(e => e.Deal).Load();
            if (dealActions == null)
            {
                return HttpNotFound();
            }
            return View(dealActions);
        }

        // GET: DealActions/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login");
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title");
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login");
            ViewBag.UserId = new SelectList(db.User, "Id", "Login");
            return View();
        }

        // POST: DealActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Type,Date,Note,LastEditTime,UserId,ContractorId,CreatorId,LastEditor,DealId")] DealActions dealActions)
        {
            if (ModelState.IsValid)
            {
                db.DealActions.Add(dealActions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", dealActions.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealActions.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealActions.DealId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", dealActions.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", dealActions.UserId);
            return View(dealActions);
        }

        // GET: DealActions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealActions dealActions = await db.DealActions.FindAsync(id);
            if (dealActions == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", dealActions.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealActions.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealActions.DealId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", dealActions.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", dealActions.UserId);
            return View(dealActions);
        }

        // POST: DealActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Type,Date,Note,LastEditTime,UserId,ContractorId,CreatorId,LastEditor,DealId")] DealActions dealActions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealActions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", dealActions.ContractorId);
            ViewBag.CreatorId = new SelectList(db.User, "Id", "Login", dealActions.CreatorId);
            ViewBag.DealId = new SelectList(db.Deal, "Id", "Title", dealActions.DealId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "Login", dealActions.LastEditor);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", dealActions.UserId);
            return View(dealActions);
        }

        // GET: DealActions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealActions dealActions = await db.DealActions.FindAsync(id);

         

            if (dealActions == null)
            {
                return HttpNotFound();
            }
            return View(dealActions);
        }

        // POST: DealActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DealActions dealActions = await db.DealActions.FindAsync(id);
            db.DealActions.Remove(dealActions);
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
