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
using System.Web.UI.WebControls;

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
            return false;
        }

        private bool checkbank(BankAccount Bank)
        {
            if (db.BankAccount.Any(e => e.BankAccountNumber == Bank.BankAccountNumber && e.CardNumber == Bank.CardNumber))
            {
                return true;
            }
            return false;
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
            var bank = user.BankAccountSets.FirstOrDefault();
            var viewModel = new UserCreatorBase
            {
                Address = adres,
                User = user,
                Contact = contact,
                Bank = bank,
                BankAccountNumber = Rsa.RsaDecrypt(bank.BankAccountNumber,db),
                CardNumber = Rsa.RsaDecrypt(bank.CardNumber,db),
                Pesel = Convert.ToInt64(Rsa.RsaDecrypt(user.PESEL,db)),
                IDNumber = Rsa.RsaDecrypt(user.IDNumber,db)
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
        public async Task<ActionResult> Create([Bind(Include = "FirstName,Login,Password,Surname,Pesel,DateOfBirth,Sex,PlaceOfBirth,IDNumber,Notes,ReferId,ContractorId,MoneyBoxId,IsWorker,BankAccountNumber,CardNumber,BankName,Address,Contact")]UserCreator ViewUser)
        {
            if (ModelState.IsValid)
            {
              //  Object create
                var contact = ViewUser.Contact;
                var address = ViewUser.Address;
                var user = new User()
                {
                    FirstName = ViewUser.FirstName,
                    Login = ViewUser.Login,
                    Password = Rsa.RsaEncrypt(ViewUser.Password,db),
                    Surname = ViewUser.Surname,
                    PESEL = Rsa.RsaEncrypt(ViewUser.Pesel, db),
                    DateOfBirth = ViewUser.DateOfBirth,
                    Sex = ViewUser.Sex,
                    PlaceOfBirth = ViewUser.PlaceOfBirth,
                    IDNumber = Rsa.RsaEncrypt(ViewUser.IDNumber,db),
                    Notes = ViewUser.Notes,
                    ContractorId = ViewUser.ContractorId,
                    MoneyboxId = ViewUser.MoneyBoxId,
                    IsWorker = ViewUser.IsWorker
                };



                var bank = new BankAccount()
                {
                    BankAccountNumber = Rsa.RsaEncrypt(ViewUser.BankAccountNumber,db),
                    CardNumber = Rsa.RsaEncrypt(ViewUser.CardNumber,db),
                    BankName = ViewUser.BankName
                };



                // Check for exist
                if (checkbank(bank))
                {
                    user.BankAccountSets.Add(bank);
                }
                else
                {
                    db.BankAccount.Add(bank);
                    db.SaveChanges();
                    user.BankAccountSets.Add(bank);
                }

                if (checkAddress(address))
                {
                    user.MainAddress = AddressId(address);
                }
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    user.MainAddress = address.Id; 
                }


                // Set for Refer
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

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", ViewUser.MoneyBoxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", ViewUser.ReferId);
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
            ViewBag.BankId = new SelectList(db.BankAccount, "Id", "BankName", user.BankAccountSets);

            var ViewUser = new UserCreator
            {
                Address = address,
                MoneyBoxId = user.MoneyboxId,
                AddressOldId=address.Id,
                Contact = contact,
                FirstName = user.FirstName,
                Login = user.Login,
                Surname = user.Surname,
                Pesel = Rsa.RsaDecrypt(user.PESEL,db),
                DateOfBirth = user.DateOfBirth,
                Sex = user.Sex,
                PlaceOfBirth = user.PlaceOfBirth,
                IDNumber = Rsa.RsaDecrypt(user.IDNumber, db),
                Notes = user.Notes,
                IsWorker = user.IsWorker,
                ContactId = contact.Id
            };


            return View(ViewUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DeleteOldBank,ContactId,JoinDate,Id,AddressOldId,FirstName,Login,Password,Surname,Pesel,DateOfBirth,Sex,PlaceOfBirth,IDNumber,Notes,ReferId,ContractorId,MoneyBoxId,IsWorker,BankId,Address,Contact")]UserCreator ViewUser)
        {

            if (ModelState.IsValid)
            {
                
                var address = ViewUser.Address;

                var contact = db.Contact.First(e => e.Id == ViewUser.ContactId);

                contact.Skype = ViewUser.Contact.Skype;
                contact.PhoneNumber = ViewUser.Contact.PhoneNumber;
                contact.MobileNumber = ViewUser.Contact.MobileNumber;
                contact.FaxNumber = ViewUser.Contact.FaxNumber;
                contact.Email = ViewUser.Contact.Email;

                var user = db.User.First(e => e.Id == ViewUser.Id);


                user.FirstName = ViewUser.FirstName;
                user.Login = ViewUser.Login;
                user.Password = Rsa.RsaEncrypt(ViewUser.Password, db);
                user.Surname = ViewUser.Surname;
                user.PESEL = Rsa.RsaEncrypt(ViewUser.Pesel, db);
                user.DateOfBirth = ViewUser.DateOfBirth;
                user.Sex = ViewUser.Sex;
                user.PlaceOfBirth = ViewUser.PlaceOfBirth;
                user.IDNumber = Rsa.RsaEncrypt(ViewUser.IDNumber, db);
                user.Notes = ViewUser.Notes;
                user.ContractorId = ViewUser.ContractorId;
                user.MoneyboxId = ViewUser.MoneyBoxId;
                user.IsWorker = ViewUser.IsWorker;
                user.ReferId = ViewUser.ReferId;



                var bank = db.BankAccount.First(e => e.Id == ViewUser.BankId);
                //var contact = db.Contact.First(e => e.Id == )




                if (user.BankAccountSets.Any(e => e.Equals(bank)))
                {
                   // do nothing. 
                }
                else if (checkbank(bank) && !user.BankAccountSets.Any(e => e.Equals(bank)))
                {
                    if (ViewUser.DeleteOldBank)
                    {
                        user.BankAccountSets.Remove(user.BankAccountSets.FirstOrDefault());
                    }
                    user.BankAccountSets.Add(bank);
                }
                else
                {
                    db.BankAccount.Add(bank);
                    db.SaveChanges();
                    user.BankAccountSets.Add(bank);
                }



                if (checkAddress(address))
                {
                    user.MainAddress = AddressId(address);
                }
                else
                {
                    db.Address.Add(ViewUser.Address);
                    db.SaveChanges();
                    ViewUser.MainAddress = ViewUser.Address.Id;
                }
                
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();


                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();

                var entity = await db.Address.FindAsync(ViewUser.AddressOldId);

                if (entity.MainAddressUser.Count == 0 && entity.SecondAddressUser.Count == 0 && entity.MainAddressContractor.Count == 0 && entity.SecondAddressContractor.Count == 0)
                    db.Address.Remove(entity);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.ContractorId);
            ViewBag.MoneyboxId = new SelectList(db.Moneybox, "Id", "Id", ViewUser.MoneyBoxId);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", ViewUser.ReferId);
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
            var ViewUser = new UserCreatorBase
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
            ViewBag.User = new SelectList(db.User, "Id", "Login");
            ViewBag.Bank = new SelectList(db.BankAccount, "Id", "Id");
            return View();
        }


        // POST: Users/AddBankAccout
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBankAccount([Bind(Include = "User,Bank,Login")] UserAndBank UserBankView)
        {
            if (ModelState.IsValid)
            {
                var user = db.User.First(e => e.Id == UserBankView.User);
                var bank = user.BankAccountSets.SingleOrDefault(e => e.Id == UserBankView.Bank);
                if (bank == null)
                    user.BankAccountSets.Add(db.BankAccount.Single(e => e.Id == UserBankView.Bank));

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.User, "Id", "Login", UserBankView.User);
            ViewBag.Id = new SelectList(db.BankAccount, "Id", "Id", UserBankView.Bank);
            return View();
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

