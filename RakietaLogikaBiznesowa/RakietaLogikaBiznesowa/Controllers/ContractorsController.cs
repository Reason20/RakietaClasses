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
    public class ContractorsController : Controller
    {
        private int AddressId(Address address)
        {
            return db.Address.First(o => o.HouseNumber == address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province == address.Province && o.Street == address.Street && o.Country == address.Country).Id;
        }

        private bool checkAddress(Address address)
        {
            if (db.Address.Any(o => o.HouseNumber == address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province == address.Province && o.Street == address.Street && o.Country == address.Country))
            {
                return true;
            }
            else return false;
        }
        private Model1 db = new Model1();

        // GET: Contractors
        public async Task<ActionResult> Index()
        {
            var contractor = db.Contractor/*.Include(c => c.Editor).Include(c => c.MainAddressContractor).Include(c => c.SecondAddressContractor)*/;
            return View(await contractor.ToListAsync());
        }

        // GET: Contractors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = await db.Contractor.FindAsync(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            Address adres = await db.Address.FindAsync(contractor.MainAddress);
            if (adres == null)
                return HttpNotFound();
            return View(contractor);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street");
            ViewBag.SecondAddress = new SelectList(db.Address, "Id", "Street");
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Pesel,NIP,REGON,Name,FirstName,SecondName,Comments,MainAddress,SecondAddress,LastEditTime,LastEditor")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                db.Contractor.Add(contractor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contractor.LastEditor);
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", contractor.MainAddress);
            ViewBag.SecondAddress = new SelectList(db.Address, "Id", "Street", contractor.SecondAddress);
            return View(contractor);
        }

        // GET: Contractors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = await db.Contractor.FindAsync(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contractor.LastEditor);
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", contractor.MainAddress);
            ViewBag.SecondAddress = new SelectList(db.Address, "Id", "Street", contractor.SecondAddress);
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Pesel,NIP,REGON,Name,FirstName,SecondName,Comments,MainAddress,SecondAddress,LastEditTime,LastEditor")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contractor.LastEditor);
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", contractor.MainAddress);
            ViewBag.SecondAddress = new SelectList(db.Address, "Id", "Street", contractor.SecondAddress);
            return View(contractor);
        }

        // GET: Contractors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = await db.Contractor.FindAsync(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contractor contractor = await db.Contractor.FindAsync(id);
            db.Contractor.Remove(contractor);
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
