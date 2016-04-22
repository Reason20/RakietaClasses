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
            ContractorAndAddress ViewContractor = new ContractorAndAddress();
            ViewContractor.Address = adres;
            ViewContractor.Contractor = contractor;
            return View(ViewContractor);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street");
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Address,Contractor")] ContractorAndAddress ViewContractor)
        {
            if (ModelState.IsValid)
            {
                Address address = ViewContractor.Address;
                Contractor contractor = ViewContractor.Contractor;
                if (checkAddress(address) == true)
                    contractor.MainAddress = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    contractor.MainAddress = address.Id;
                }
                db.Contractor.Add(contractor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", ViewContractor.Contractor.MainAddress);
            return View(ViewContractor);
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
            var address = await db.Address.FindAsync(contractor.MainAddress);
            if(address == null)
            {
                return HttpNotFound();
            }

            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", contractor.MainAddress);
            var ViewContractor = new ContractorAndAddress
            {
                Address = address,
                Contractor = contractor,
                AddressOldId=address.Id
            };

            return View(ViewContractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Contractor,Address,AddressOldId")] ContractorAndAddress ViewContractor)
        {
            if (ModelState.IsValid)
            {
                var address = ViewContractor.Address;
                var contractor = ViewContractor.Contractor;
                if (checkAddress(address) == true)
                    ViewContractor.Contractor.MainAddress = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    contractor.MainAddress = address.Id;
                }
                db.Entry(contractor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var foo = await db.Address.FindAsync(ViewContractor.AddressOldId);
                if (foo.MainAddressUser.Count == 0 && foo.SecondAddressUser.Count == 0 && foo.MainAddressContractor.Count == 0 && foo.SecondAddressContractor.Count == 0)
                    db.Address.Remove(foo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contractor.LastEditor);
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", ViewContractor.Contractor.MainAddress);
            //ViewBag.SecondAddress = new SelectList(db.Address, "Id", "Street", contractor.SecondAddress);
            return View(ViewContractor);
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
            var address = await db.Address.FindAsync(contractor.MainAddress);
            if (address.MainAddressUser.Count == 0 && address.SecondAddressUser.Count == 0 && address.MainAddressContractor.Count == 0 && address.SecondAddressContractor.Count == 0)
                db.Address.Remove(address);
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
