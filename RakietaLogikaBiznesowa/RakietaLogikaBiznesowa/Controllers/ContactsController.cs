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
    public class ContactsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var contact = db.Contact.Include(c => c.ClubContact).Include(c => c.ContactCont).Include(c => c.ContactUser).Include(c => c.Editor);
            return View(await contact.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contact.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Entry(contact).Reference(e => e.ClubContact).Load();
            db.Entry(contact).Reference(e => e.ContactCont).Load();
            db.Entry(contact).Reference(e => e.ContactUser).Load();
            db.Entry(contact).Reference(e => e.Editor).Load();
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name");
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName");
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Skype,PhoneNumber,MobileNumber,FaxNumber,Email,ContractorId,UserId,ClubId,LastEditTime,LastEditor")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", contact.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", contact.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", contact.UserId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contact.LastEditor);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contact.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", contact.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", contact.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", contact.UserId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contact.LastEditor);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Skype,PhoneNumber,MobileNumber,FaxNumber,Email,ContractorId,UserId,ClubId,LastEditTime,LastEditor")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", contact.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", contact.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", contact.UserId);
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contact.LastEditor);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contact.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Entry(contact).Reference(e => e.ClubContact).Load();
            db.Entry(contact).Reference(e => e.ContactCont).Load();
            db.Entry(contact).Reference(e => e.ContactUser).Load();
            db.Entry(contact).Reference(e => e.Editor).Load();
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contact contact = await db.Contact.FindAsync(id);
            db.Contact.Remove(contact);
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
