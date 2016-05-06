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

        //private int checkbank(BankConstructor BankC)
        //{
        //    BankAccount Bank = new BankAccount()
        //    {
        //        BankAccountNumber = Rsa.RsaEncrypt(BankC.BankAccountNumber, db),
        //        CardNumber = Rsa.RsaEncrypt(BankC.CardNumber, db),
        //        BankName = BankC.Bank.BankName
        //    };

        //    if (db.BankAccount.Any(e => e.BankAccountNumber == Bank.BankAccountNumber || e.CardNumber == Bank.CardNumber))
        //    {
        //        var bankFromDb =
        //            db.BankAccount.Single(
        //                e => e.BankAccountNumber == Bank.BankAccountNumber || e.CardNumber == Bank.CardNumber);
        //        return bankFromDb.Id;
        //    }
        //    return 0;
        //}

        //private BankAccount addBankAccount(BankConstructor bank)
        //{
        //    var id = checkbank(bank);
        //    BankAccount CreatedBank = new BankAccount();
        //    if (id == 0)
        //    {
        //        if (bank.BankAccountNumber == string.Empty)
        //        {
        //            CreatedBank = new BankAccount()
        //            {
        //                CardNumber = Rsa.RsaEncrypt(bank.CardNumber, db),
        //                BankName = bank.Bank.BankName
        //            };
        //            db.SaveChanges();
        //        }
        //        else if (bank.CardNumber == string.Empty)
        //        {
        //            CreatedBank = new BankAccount()
        //            {
        //                BankAccountNumber = Rsa.RsaEncrypt(bank.BankAccountNumber, db),
        //                BankName = bank.Bank.BankName
        //            };
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            CreatedBank = new BankAccount()
        //            {
        //                BankAccountNumber = Rsa.RsaEncrypt(bank.BankAccountNumber, db),
        //                CardNumber = Rsa.RsaEncrypt(bank.CardNumber, db),
        //                BankName = bank.Bank.BankName
        //            };
        //            db.SaveChanges();
        //        }
        //    }
        //    else
        //    {
        //        CreatedBank = db.BankAccount.Single(e => e.Id == id);
        //    }

        //    return CreatedBank;
        //}


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
            Address address = await db.Address.FindAsync(contractor.MainAddress);
            if (address == null)
                return HttpNotFound();
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.ContractorId == contractor.Id);
            ContractorConstructor ViewContractor = new ContractorConstructor {
                Address = address,
                Contact = contact,
                Name = contractor.Name,
                REGON = Rsa.RsaDecrypt(contractor.REGON,db),
                NIP = Rsa.RsaDecrypt(contractor.NIP,db),
                Comments = contractor.Comments
            };
            return View(ViewContractor);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Address,Contractor,Contact,NIP,REGON,Name,Comments,LastEditTime")] ContractorConstructor ViewContractor)
        {
            if (ModelState.IsValid)
            {
                var contact = ViewContractor.Contact;
                Address address = ViewContractor.Address;

                Contractor contractor = new Contractor
                {
                    Name = ViewContractor.Name,
                    NIP = Rsa.RsaEncrypt(ViewContractor.NIP, db),
                    REGON = Rsa.RsaEncrypt(ViewContractor.REGON, db),
                    Comments = ViewContractor.Comments
                };


                if (checkAddress(address) == true)
                    contractor.MainAddress = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    contractor.MainAddress = address.Id;
                }
                db.Contractor.Add(contractor);
                try {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    db.Contractor.Remove(contractor);
                    db.Address.Remove(address);
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                contact.ContractorId = contractor.Id;
                db.Contact.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.ContractorId == contractor.Id);
            ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", contractor.MainAddress);
            ContractorConstructor ViewContractor = new ContractorConstructor
            {
                Address = address,
                Contact = contact,
                Name = contractor.Name,
                REGON = Rsa.RsaDecrypt(contractor.REGON, db),
                NIP = Rsa.RsaDecrypt(contractor.NIP, db),
                Comments = contractor.Comments,
                AddressOldId = address.Id
            };

            return View(ViewContractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NIP,REGON,Name,Comments,LastEditTime,Contractor,Address,AddressOldId,Contact,Id")] ContractorConstructor ViewContractor)
        {
            if (ModelState.IsValid)
            {
                var address = ViewContractor.Address;
                var contact = ViewContractor.Contact;

                var contractor = db.Contractor.Single(e => e.Id == ViewContractor.Id);

                contractor.Name = ViewContractor.Name;
                contractor.NIP = Rsa.RsaEncrypt(ViewContractor.NIP, db);
                contractor.REGON = Rsa.RsaEncrypt(ViewContractor.REGON, db);
                contractor.Comments = ViewContractor.Comments;


                if (checkAddress(address) == true)
                    contractor.MainAddress = AddressId(address);
                else
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    contractor.MainAddress = address.Id;
                }
                db.Entry(contractor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                contact.ContractorId = contractor.Id;
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var foo = await db.Address.FindAsync(ViewContractor.AddressOldId);
                if (foo.MainAddressUser.Count == 0 && foo.SecondAddressUser.Count == 0 && foo.MainAddressContractor.Count == 0 && foo.SecondAddressContractor.Count == 0 && foo.ClubAddress.Count == 0)
                    db.Address.Remove(foo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", contractor.LastEditor);
            //ViewBag.MainAddress = new SelectList(db.Address, "Id", "Street", ViewContractor.Contractor.MainAddress);
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
            var address = await db.Address.FindAsync(contractor.MainAddress);
            if (address == null)
            {
                return HttpNotFound();
            }
            var contact = await db.Contact.SingleOrDefaultAsync(con => con.ContractorId == contractor.Id);
            ContractorConstructor ViewContractor = new ContractorConstructor
            {
                Address = address,
                Contact = contact,
                Name = contractor.Name,
                REGON = Rsa.RsaDecrypt(contractor.REGON, db),
                NIP = Rsa.RsaDecrypt(contractor.NIP, db),
                Comments = contractor.Comments
            };
            return View(ViewContractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contractor contractor = await db.Contractor.FindAsync(id);
            foreach(User us in db.User)
            {
                if (us.ContractorId == id)
                    us.ContractorId = 1;
            }
            var address = await db.Address.FindAsync(contractor.MainAddress);
            if (address.MainAddressUser.Count == 0 && address.SecondAddressUser.Count == 0 && address.MainAddressContractor.Count == 0 && address.SecondAddressContractor.Count == 0 && address.ClubAddress.Count == 0)
                db.Address.Remove(address);
            var contact = await db.Contact.SingleOrDefaultAsync(cont => cont.ContractorId == contractor.Id);
            if (contact != null)
                db.Contact.Remove(contact);
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
