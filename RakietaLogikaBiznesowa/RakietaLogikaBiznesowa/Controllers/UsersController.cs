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
    public class UsersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var user = db.User;//(from us in db.User join ad in db.Address on us.MainAddress equals ad.Id select us);
            return View(await user.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);//(from us in db.User join ad in db.Address on us.MainAddress equals ad.Id where us.Id == id select us).ToListAsync();
            if (user == null)
            {
                return HttpNotFound();
            }
            Address adres = await db.Address.FindAsync(user.MainAddress);
            if (adres == null)
                return HttpNotFound();
            UsersAndAddress foo = new UsersAndAddress();
            foo.Address = adres;
            foo.User = user;
            return View(foo);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id");
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "User,Address,MoneyboxId,Login")]UsersAndAddress userandaddress)
        {
            if (ModelState.IsValid)
            {
                Address address = userandaddress.Address;
                User user = userandaddress.User;
                if (db.Address.Any(o => o.HouseNumber==address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province==address.Province && o.Street==address.Street && o.Country == address.Country))
                {
                    user.MainAddress = db.Address.First(o => o.HouseNumber == address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province == address.Province && o.Street == address.Street && o.Country == address.Country).Id;

                }
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    user.MainAddress = address.Id;
                }

                user.MoneyboxId = userandaddress.MoneyboxId;
                user.ReferId = userandaddress.Login;
                //user.MoneyboxId = 1;
                db.User.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", userandaddress.User.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", userandaddress.User.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", userandaddress.User.ReferId);
            ViewBag.LastEditTime = (DateTime.Now);
            ViewBag.JoinDate = DateTime.Now;
            return View(userandaddress);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Address address = await db.Address.FindAsync(user.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", user.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", user.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", user.ReferId);
            UsersAndAddress foo = new UsersAndAddress();
            foo.Address = address;
            foo.User = user;
            foo.MoneyboxId = user.MoneyboxId;
            return View(foo);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User,Address,MoneyboxId,Login")]UsersAndAddress userandaddress)
        {
            if (ModelState.IsValid)
            {
                Address address = userandaddress.Address;
                User user = userandaddress.User;
                if (db.Address.Any(o => o.HouseNumber == address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province == address.Province && o.Street == address.Street && o.Country == address.Country))
                {
                    user.MainAddress = db.Address.First(o => o.HouseNumber == address.HouseNumber && o.ApartmentNumber == address.ApartmentNumber && o.City == address.City && o.PostalCode == address.PostalCode && o.Province == address.Province && o.Street == address.Street && o.Country == address.Country).Id;

                }
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    user.MainAddress = address.Id;
                }

                user.MoneyboxId = userandaddress.MoneyboxId;
                user.ReferId = userandaddress.Login;
                //user.MoneyboxId = 1;
                db.User.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", userandaddress.User.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", userandaddress.User.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", userandaddress.User.ReferId);
            ViewBag.LastEditTime = (DateTime.Now);
            return View(userandaddress);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.User.FindAsync(id);
            db.User.Remove(user);
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
