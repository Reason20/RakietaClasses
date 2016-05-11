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
    public class ContractsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Contracts
        public async Task<ActionResult> Index()
        {
            var contract = db.Contract.Include(c => c.Editor).Include(c => c.Worker);
            return View(await contract.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contract.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AgreementDate,From,To,IsValid,Salary,Payday,WorkingHours,Type,WorkerId,LastEditTime,LastEditor")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contract.Add(contract);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contract.LastEditor);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", contract.WorkerId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contract.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contract.LastEditor);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", contract.WorkerId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AgreementDate,From,To,IsValid,Salary,Payday,WorkingHours,Type,WorkerId,LastEditTime,LastEditor")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contract.LastEditor);
            ViewBag.WorkerId = new SelectList(db.User, "Id", "FirstName", contract.WorkerId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = await db.Contract.FindAsync(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contract contract = await db.Contract.FindAsync(id);
            db.Contract.Remove(contract);
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
