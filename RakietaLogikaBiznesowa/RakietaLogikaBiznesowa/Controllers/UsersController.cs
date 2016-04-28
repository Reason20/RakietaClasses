using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RakietaLogikaBiznesowa.Models;
using System.Security.Cryptography;
using static System.Net.HttpStatusCode;
using System.Net;

namespace RakietaLogikaBiznesowa.Controllers
{
    public class UsersController : Controller
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
            else return false;
        }


        // GET: Users
        public async Task<ActionResult> Index()
        {
           // RsaInitializer();
            var user = db.User;//(from us in db.User join ad in db.Address on us.MainAddress equals ad.Id select us);
            return View(await user.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(BadRequest);
            }
            var user = await db.User.FindAsync(id);//(from us in db.User join ad in db.Address on us.MainAddress equals ad.Id where us.Id == id select us).ToListAsync();
            if (user == null)
            {
                return HttpNotFound();
            }
            var adres = await db.Address.FindAsync(user.MainAddress);
            if (adres == null)
                return HttpNotFound();
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            var viewModel = new UsersAndAddress
            {
                Address = adres,
                User = user,
                Contact = contact
            };
            return View(viewModel);
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
        public async Task<ActionResult> Create([Bind(Include = "User,Address,ReferId,Password,MoneyboxId,Contact")]UsersAndAddress ViewUser)
        {
            if (ModelState.IsValid)
            {
              //  RsaInitializer();
                var contact = ViewUser.Contact;
                var address = ViewUser.Address;
                var user = ViewUser.User;

           //     AesInitializer(user.PESEL);


                if (checkAddress(address) == true)
                {
                    user.MainAddress = AddressId(address);
                }
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    user.MainAddress = address.Id; 
                }
                user.Password = Rsa.RsaEncrypt(ViewUser.Password,db);

                user.MoneyboxId = ViewUser.MoneyboxId;
                if (ViewUser.ReferId == 0)
                    user.ReferId = null;
                else
                user.ReferId = ViewUser.ReferId;
                db.User.Add(user);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    db.User.Remove(user);
                    db.Address.Remove(address);
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                await db.SaveChangesAsync();
                contact.UserId = user.Id;
                db.Contact.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.User.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", ViewUser.User.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", ViewUser.User.ReferId);
            ViewBag.LastEditTime = (DateTime.Now);
            ViewBag.JoinDate = DateTime.Now;
            return View(ViewUser);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(BadRequest);
            }
            var user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var address = await db.Address.FindAsync(user.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", user.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", user.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", user.ReferId);

            var ViewUser = new UsersAndAddress
            {
                Address = address,
                User = user,
                MoneyboxId = user.MoneyboxId,
                AddressOldId=address.Id,
                Contact = contact
            };


            return View(ViewUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User,Address,ReferId,Password,MoneyboxId,AddressOldId,Contact")]UsersAndAddress ViewUser)
        {
            if (ModelState.IsValid)
            {
                
                var address = ViewUser.Address;
                var user = ViewUser.User;
                var contact = ViewUser.Contact;
                if (checkAddress(address))
                {
                    ViewUser.User.MainAddress = AddressId(address);
                }
                else
                {
                    db.Address.Add(ViewUser.Address);
                    db.SaveChanges();
                    ViewUser.User.MainAddress = ViewUser.Address.Id;
                }
                


                var password = Rsa.RsaEncrypt(ViewUser.Password,db);

                user.Password = password;

                user.MoneyboxId = ViewUser.MoneyboxId;
                user.ReferId = ViewUser.ReferId;
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                contact.UserId = user.Id;
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var foo = await db.Address.FindAsync(ViewUser.AddressOldId);
                if (foo.MainAddressUser.Count == 0 && foo.SecondAddressUser.Count == 0 && foo.MainAddressContractor.Count == 0 && foo.SecondAddressContractor.Count == 0)
                    db.Address.Remove(foo);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.User.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", ViewUser.User.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", ViewUser.User.ReferId);
            ViewBag.LastEditTime = (DateTime.Now);
            return View(ViewUser);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var address = await db.Address.FindAsync(user.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            var ViewUser = new UsersAndAddress
            {
                Address = address,
                User = user,
                MoneyboxId = user.MoneyboxId,
                AddressOldId = address.Id,
                Contact = contact
            };
            return View(ViewUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.User.FindAsync(id);
            foreach(User us in db.User)
            {
                if (us.LastEditor == id)
                    us.LastEditor = null;
                if (us.ReferId == id)
                    us.ReferId = null;
            }
            foreach(Role rola in db.Role)
            {
                if (rola.LastEditor == id)
                    rola.LastEditor = null;
            }
            var address = await db.Address.FindAsync(user.MainAddress);
            if (address.MainAddressUser.Count == 0 && address.SecondAddressUser.Count == 0 && address.MainAddressContractor.Count == 0 && address.SecondAddressContractor.Count == 0)
                db.Address.Remove(address);
            var contact = await db.Contact.SingleOrDefaultAsync(cont => cont.UserId == user.Id);
            if(contact!=null)
                db.Contact.Remove(contact);
            db.User.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // GET: Users/AddBankAccount
        public ActionResult AddBankAccount()
        {
            ViewBag.Login = new SelectList(db.User, "Id", "Login");
            ViewBag.Id = new SelectList(db.BankAccount, "Id", "Id");
            return View();
        }
        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBankAccount(
            [Bind(Include = "User,Bank")] UserAndBank UserBankView)
        {

            var user = db.User.First(e => e.Id == UserBankView.User.Id);
            var bank = user.BankAccountSets.SingleOrDefault(e => e.Id == UserBankView.Bank.Id);
            if (bank == null)
                user.BankAccountSets.Add(db.BankAccount.Single(e => e.Id == UserBankView.Bank.Id));

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

