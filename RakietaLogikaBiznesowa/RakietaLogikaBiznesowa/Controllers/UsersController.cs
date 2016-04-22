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

namespace RakietaLogikaBiznesowa.Controllers
{
    public class UsersController : Controller
    {
        private Model1 db = new Model1();

        // ONLY FOR DEBUG.
        //private void RsaInitializer()
        //{
        //    RSACryptoServiceProvider rsaInitializer = new RSACryptoServiceProvider(4096);

        //    var rsaModel = new rsa()
        //    {
        //        publicKey = rsaInitializer.ToXmlString(false),
        //        privateKey = rsaInitializer.ToXmlString(true)
        //    };

        //    db.Rsa.Add(rsaModel);
        //    db.SaveChanges();
        //}
        // ONLY FOR DEBUG

        //private string RsaEncrypt(string message)
        //{
        //    var rsaServiceProvider = new RSACryptoServiceProvider();
        //    var rsaFromDb = db.Rsa.FirstOrDefault(e => e.Id == 1);

        //    rsaServiceProvider.FromXmlString(rsaFromDb.publicKey);

        //    var buffer = System.Text.Encoding.ASCII.GetBytes(message);
            
        //    var cryptedBytes = rsaServiceProvider.Encrypt(buffer, true);

        //    var cryptedString = BitConverter.ToString(cryptedBytes);

        //    return cryptedString;
        //}

        //private string RsaDecrypt(string message)
        //{
        //    var rsaServiceProvider = new RSACryptoServiceProvider();
        //    var rsaFromDb = db.Rsa.FirstOrDefault(e => e.Id == 1);

        //    rsaServiceProvider.FromXmlString(rsaFromDb.privateKey);

        //    var buffer = System.Text.Encoding.ASCII.GetBytes(message);

        //    var decryptedBytes = rsaServiceProvider.Decrypt(buffer, true);

        //    var decryptedString = BitConverter.ToString(decryptedBytes);

        //    return decryptedString;

        //}


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
            var viewModel = new UsersAndAddress
            {
                Address = adres,
                User = user
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
        public async Task<ActionResult> Create([Bind(Include = "User,Address,ReferId,MoneyboxId")]UsersAndAddress ViewUser)
        {
            if (ModelState.IsValid)
            {
                var address = ViewUser.Address;
                var user = ViewUser.User;
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
               // user.Password = RsaEncrypt(ViewUser.User.Password);

             //   var test = RsaDecrypt(user.Password);

                user.MoneyboxId = ViewUser.MoneyboxId;
                if (ViewUser.ReferId == 0)
                    user.ReferId = null;
                else
                user.ReferId = ViewUser.ReferId;
                db.User.Add(user);
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

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", user.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", user.MoneyboxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", user.ReferId);

            var ViewUser = new UsersAndAddress
            {
                Address = address,
                User = user,
                MoneyboxId = user.MoneyboxId,
                AddressOldId=address.Id
            };


            return View(ViewUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User,Address,ReferId,MoneyboxId,AddressOldId")]UsersAndAddress ViewUser)
        {
            if (ModelState.IsValid)
            {
                var address = ViewUser.Address;
                var user = ViewUser.User;
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


          //      var password = RsaEncrypt(ViewUser.User.Password);

                //user.Password = password;
                

                user.MoneyboxId = ViewUser.MoneyboxId;
                user.ReferId = ViewUser.ReferId;
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var foo = await db.Address.FindAsync(ViewUser.AddressOldId);
                if (foo.MainAddressUser.Count == 0 && foo.SecondAddressUser.Count == 0 && foo.MainAddressContractor.Count == 0 && foo.SecondAddressContractor.Count == 0)
                    db.Address.Remove(foo);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.User.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id of Monexbox", ViewUser.User.MoneyboxId);
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
            return View(user);
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
