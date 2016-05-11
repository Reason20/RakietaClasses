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
    public class ClubsController : Controller
    {
        private Model1 db = new Model1();
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
            return false;
        }

        // GET: Clubs
        public async Task<ActionResult> Index()
        {
            var clubs = db.Club.Include(c => c.ClubAddress).Include(c => c.Editor);
            List<ClubConstractor> Lista = new List<ClubConstractor>();
            foreach (Club club in clubs.ToList())
            {
                ClubConstractor club2 = new ClubConstractor
                {
                    id=club.Id,
                    Name=club.Name,
                    Address=db.Address.Find(club.AddressId),
                    AddressOldId=club.AddressId,
                    Contact= db.Contact.SingleOrDefault(con => con.ClubId == club.Id)
                };
                Lista.Add(club2);
            }
            return View(Lista);
        }

        // GET: Clubs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Club.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            Address address = await db.Address.FindAsync(club.AddressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            Contact contact = await db.Contact.FirstOrDefaultAsync(con => con.ClubId == club.Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ClubConstractor clubs = new ClubConstractor
            {
                id = club.Id,
                Name = club.Name,
                Address = address,
                AddressOldId = address.Id,
                Contact = contact
            };
            return View(clubs);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            //ViewBag.AddressId = new SelectList(db.Address, "Id", "Street");
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,Contact,AddressOldId")] ClubConstractor club)
        {
            if (ModelState.IsValid)
            {
                var clubs = new Club();
                var address = club.Address;
                var contact = club.Contact;
                if (checkAddress(address) == true)
                    clubs.AddressId = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    clubs.AddressId = address.Id;
                }
                clubs.LastEditor = 52;
                clubs.LastEditTime = DateTime.Now;
                clubs.Name = club.Name;
                db.Club.Add(clubs);
                await db.SaveChangesAsync();
                contact.ClubId = clubs.Id;
                db.Contact.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.AddressId = new SelectList(db.Address, "Id", "Street", club.AddressId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", club.LastEditor);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Club.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            Address address = await db.Address.FindAsync(club.AddressId);
            if(address == null)
            {
                return HttpNotFound();
            }
            Contact contact = await db.Contact.FirstOrDefaultAsync(con => con.ClubId == club.Id);
            if(contact == null)
            {
                return HttpNotFound();
            }
            ClubConstractor clubs = new ClubConstractor
            {
                id = club.Id,
                Name = club.Name,
                Address = address,
                AddressOldId = address.Id,
                Contact = contact
            };
            //ViewBag.AddressId = new SelectList(db.Address, "Id", "Street", club.AddressId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", club.LastEditor);
            return View(clubs);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Contact,AddressOldId")] ClubConstractor club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club.Contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var clubs = db.Club.First(e => e.Id == club.id);
                clubs.Name = club.Name;
                clubs.LastEditor = 52;
                clubs.LastEditTime = DateTime.Now;
                var address = club.Address;
                if (checkAddress(address) == true)
                    clubs.AddressId = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    clubs.AddressId = address.Id;
                }
                db.Entry(clubs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var entity = await db.Address.FindAsync(club.AddressOldId);

                if (entity.MainAddressUser.Count == 0 && entity.SecondAddressUser.Count == 0 && entity.MainAddressContractor.Count == 0 && entity.SecondAddressContractor.Count == 0 && entity.ClubAddress.Count == 0)
                    db.Address.Remove(entity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.AddressId = new SelectList(db.Address, "Id", "Street", club.AddressId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", club.LastEditor);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Club.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            Address address = await db.Address.FindAsync(club.AddressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            Contact contact = await db.Contact.FirstOrDefaultAsync(con => con.ClubId == club.Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ClubConstractor clubs = new ClubConstractor
            {
                id = club.Id,
                Name = club.Name,
                Address = address,
                AddressOldId = address.Id,
                Contact = contact
            };
            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Club club = await db.Club.FindAsync(id);
            var contact = await db.Contact.SingleOrDefaultAsync(cont => cont.ClubId == club.Id);
            if (contact != null)
                db.Contact.Remove(contact);
            foreach(Rooms room in db.Rooms)
            {
                if (room.ClubId == id)
                    db.Rooms.Remove(room);
            }
            foreach (Facture facture in db.Facture)
            {
                if (facture.ClubId == id)
                {
                    facture.ClubId = null;
                    db.Entry(facture).State = EntityState.Modified;
                }
            }
            db.Club.Remove(club);
            await db.SaveChangesAsync();
            var address = await db.Address.FindAsync(club.AddressId);
            if (address.MainAddressUser.Count == 0 && address.SecondAddressUser.Count == 0 && address.MainAddressContractor.Count == 0 && address.SecondAddressContractor.Count == 0 && address.ClubAddress.Count == 0)
                db.Address.Remove(address);
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
