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

        private int checkbank(BankConstructor BankC)
        {
            BankAccount Bank = new BankAccount()
            {
                BankAccountNumber = Rsa.RsaEncrypt(BankC.BankAccountNumber, db),
                CardNumber = Rsa.RsaEncrypt(BankC.CardNumber, db),
                BankName = BankC.Bank.BankName
            };

            if (db.BankAccount.Any(e => e.BankAccountNumber == Bank.BankAccountNumber || e.CardNumber == Bank.CardNumber))
            {
                var bankFromDb =
                    db.BankAccount.Single(
                        e => e.BankAccountNumber == Bank.BankAccountNumber || e.CardNumber == Bank.CardNumber);
                return bankFromDb.Id;
            }
            return 0;
        }

        private BankAccount addBankAccount(BankConstructor bank)
        {
            var id = checkbank(bank);
            BankAccount CreatedBank = new BankAccount();
            if (id == 0)
            {
                if (bank.BankAccountNumber == string.Empty)
                {
                    CreatedBank = new BankAccount()
                    {
                        CardNumber = Rsa.RsaEncrypt(bank.CardNumber, db),
                        BankName = bank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                    db.SaveChanges();
                }
                else if (bank.CardNumber == string.Empty)
                {
                    CreatedBank = new BankAccount()
                    {
                        BankAccountNumber = Rsa.RsaEncrypt(bank.BankAccountNumber, db),
                        BankName = bank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                    db.SaveChanges();
                }
                else
                {
                    CreatedBank = new BankAccount()
                    {
                        BankAccountNumber = Rsa.RsaEncrypt(bank.BankAccountNumber, db),
                        CardNumber = Rsa.RsaEncrypt(bank.CardNumber, db),
                        BankName = bank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                    db.SaveChanges();
                }
            }
            else
            {
                CreatedBank = db.BankAccount.Single(e => e.Id == id);
            }

            return CreatedBank;
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

            db.Entry(user).Reference(e => e.MainAddressUser).Load();
            db.Entry(user).Collection(e => e.ContactSets).Load();
            db.Entry(user).Collection(e => e.BankAccountSets).Load();


            var adres = await db.Address.FindAsync(user.MainAddress);
            if (adres == null)
                return HttpNotFound();
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            var bank = user.BankAccountSets.FirstOrDefault();

            var viewModel = new UserGetter
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
            ViewBag.MoneyboxId = new SelectList(db.User, "Id", "Login");
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FirstName,Login,Password,Surname,Pesel,DateOfBirth,Sex,PlaceOfBirth,IDNumber,Notes,ReferId,ContractorId,MoneyBoxId,IsWorker,Bank,Address,Contact")]UserConstructor ViewUser)
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
                    IsWorker = ViewUser.IsWorker
                };
                if (ViewUser.MoneyBoxId != 52)
                {
                    var moneyBox = db.Moneybox.First(e => e.Id == ViewUser.MoneyBoxId);
                    user.MoneyboxId = moneyBox.Id;
                    moneyBox.NumberOfUsers++;
                    db.Entry(moneyBox).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    Moneybox foo = new Moneybox()
                    {
                        Value = 0,
                        NumberOfUsers=1
                    };
                    db.Moneybox.Add(foo);
                    await db.SaveChangesAsync();
                    user.MoneyboxId = foo.Id;
                }
                var BankAccount = addBankAccount(ViewUser.Bank);

                user.BankAccountSets.Add(BankAccount);

                // Check for exist

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
            ViewBag.MoneyboxId = new SelectList(db.User, "Id", "Login", ViewUser.MoneyBoxId);
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
            db.Entry(user).Reference(e => e.MainAddressUser).Load();
            db.Entry(user).Collection(e => e.ContactSets).Load();
            db.Entry(user).Collection(e => e.BankAccountSets).Load();

            var address = await db.Address.FindAsync(user.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }



            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", user.ContractorId);
            var moneyBox = db.User.First(e => e.MoneyboxId == user.MoneyboxId);
            ViewBag.MoneyboxId = new SelectList(db.User, "Id", "Login", moneyBox);
            ViewBag.ReferId = new SelectList(db.User, "Id", "Login", user.ReferId);
            ViewBag.BankId = new SelectList(db.BankAccount, "Id", "BankName", user.BankAccountSets);



            var bankfoo = user.BankAccountSets.First().Id;

            var ViewUser = new UserConstructor
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
                ContactId = contact.Id,
                OldMoneyBoxId = user.MoneyboxId,
                BankId = bankfoo
            };


            return View(ViewUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DeleteOldBank,ContactId,JoinDate,Id,AddressOldId,FirstName,Login,Password,Surname,Pesel,DateOfBirth,Sex,PlaceOfBirth,IDNumber,Notes,ReferId,ContractorId,MoneyBoxId,IsWorker,BankId,Bank,Address,Contact,OldMoneyBoxId")]UserConstructor ViewUser)
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
                //user.MoneyboxId = ViewUser.MoneyBoxId;
                user.IsWorker = ViewUser.IsWorker;
                user.ReferId = ViewUser.ReferId;

                var bank2 = addBankAccount(ViewUser.Bank);

                //var bank = db.BankAccount.First(e => e.Id == ViewUser.BankId);
                //var contact = db.Contact.First(e => e.Id == )



                if (ViewUser.BankId != bank2.Id)
                {
                    user.BankAccountSets.Add(bank2);
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
                var foo = db.User.First(e => e.Id == ViewUser.MoneyBoxId);
                if (ViewUser.OldMoneyBoxId != foo.MoneyboxId)
                {
                    if (ViewUser.MoneyBoxId != 52)
                    {
                        var OldMoneyBox = db.Moneybox.First(e => e.Id == ViewUser.OldMoneyBoxId);
                        var NewMoneyBox = db.Moneybox.First(e => e.Id == ViewUser.MoneyBoxId);
                        if (OldMoneyBox.Users.Count == 1)
                        {
                            
                            NewMoneyBox.Value += OldMoneyBox.Value;
                            user.MoneyboxId = NewMoneyBox.Id;
                            db.Entry(NewMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                            db.Moneybox.Remove(OldMoneyBox);
                            await db.SaveChangesAsync();
                        }
                        else
                        {
                            OldMoneyBox.NumberOfUsers--;
                            user.MoneyboxId = NewMoneyBox.Id;
                            db.Entry(NewMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                            db.Entry(OldMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        var OldMoneyBox = db.Moneybox.First(e => e.Id == ViewUser.OldMoneyBoxId);
                        var NewMoneyBox = new Moneybox()
                        {
                            Value = 0,
                            NumberOfUsers = 1
                        };
                        db.Moneybox.Add(NewMoneyBox);
                        await db.SaveChangesAsync();
                        if (OldMoneyBox.Users.Count == 1)
                        {
                            NewMoneyBox.Value += OldMoneyBox.Value;
                            user.MoneyboxId = NewMoneyBox.Id;
                            db.Entry(NewMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                            db.Moneybox.Remove(OldMoneyBox);
                            await db.SaveChangesAsync();
                        }
                        else
                        {
                            OldMoneyBox.NumberOfUsers--;
                            user.MoneyboxId = NewMoneyBox.Id;
                            db.Entry(NewMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                            db.Entry(OldMoneyBox).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }
                }
                else
                    user.MoneyboxId = ViewUser.OldMoneyBoxId;
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();


                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();

                var entity = await db.Address.FindAsync(ViewUser.AddressOldId);

                if (entity.MainAddressUser.Count == 0 && entity.SecondAddressUser.Count == 0 && entity.MainAddressContractor.Count == 0 && entity.SecondAddressContractor.Count == 0 && entity.ClubAddress.Count == 0)
                    db.Address.Remove(entity);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", ViewUser.ContractorId);
            var moneyBox = db.User.First(e => e.Id == ViewUser.MoneyBoxId);
            ViewBag.MoneyboxId = new SelectList(db.User, "Id", "Login", moneyBox);
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

            db.Entry(user).Reference(e => e.MainAddressUser).Load();
            db.Entry(user).Collection(e => e.ContactSets).Load();
            db.Entry(user).Collection(e => e.BankAccountSets).Load();


            var address = await db.Address.FindAsync(user.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.UserId == user.Id);
            var ViewUser = new UserGetter
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
            var contact = await db.Contact.SingleOrDefaultAsync(cont => cont.UserId == user.Id);
            if(contact!=null)
                db.Contact.Remove(contact);
            db.User.Remove(user);
            await db.SaveChangesAsync();
            var address = await db.Address.FindAsync(user.MainAddress);
            if (address.MainAddressUser.Count == 0 && address.SecondAddressUser.Count == 0 && address.MainAddressContractor.Count == 0 && address.SecondAddressContractor.Count == 0 && address.ClubAddress.Count == 0)
                db.Address.Remove(address);

            //TODO co zrobić z pieniędzmi, jeżeli to był użytkownik tej skarbonki? Wypłacić! Więc trzeba poczekać na zrobienie Outcomes klubu
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

