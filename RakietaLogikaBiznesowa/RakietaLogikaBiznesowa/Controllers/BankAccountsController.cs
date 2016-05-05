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
    public class BankAccountsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BankAccounts
        public async Task<ActionResult> Index()
        {
            var bankAccount = db.BankAccount.Include(b => b.Editor);
            return View(await bankAccount.ToListAsync());
        }

        // GET: BankAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccount.FindAsync(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            var ViewBank = new BankConstructor()
            {
                BankAccountNumber = Rsa.RsaDecrypt(bankAccount.BankAccountNumber, db),
                CardNumber = Rsa.RsaDecrypt(bankAccount.CardNumber, db),
            };

            ViewBank.Bank.BankName = bankAccount.BankName;


            return View(ViewBank);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BankAccountNumber,CardNumber,BankName")] BankConstructor ViewBank)
        {
            if (ModelState.IsValid)
            {
                var CreatedBank = new BankAccount();

                if (ViewBank.BankAccountNumber == string.Empty)
                {
                    CreatedBank = new BankAccount()
                    {
                        CardNumber = Rsa.RsaEncrypt(ViewBank.CardNumber, db),
                        BankName = ViewBank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                }
                else if (ViewBank.CardNumber == string.Empty)
                {
                    CreatedBank = new BankAccount()
                    {
                        BankAccountNumber = Rsa.RsaEncrypt(ViewBank.BankAccountNumber, db),
                        BankName = ViewBank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                }
                else
                {
                    CreatedBank = new BankAccount()
                    {
                        BankAccountNumber = Rsa.RsaEncrypt(ViewBank.BankAccountNumber, db),
                        CardNumber = Rsa.RsaEncrypt(ViewBank.CardNumber, db),
                        BankName = ViewBank.Bank.BankName
                    };
                    db.BankAccount.Add(CreatedBank);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ViewBank);
        }

        // GET: BankAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccount.FindAsync(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            var ViewBank = new BankConstructor()
            {
                BankAccountNumber = Rsa.RsaDecrypt(bankAccount.BankAccountNumber, db),
                CardNumber = Rsa.RsaDecrypt(bankAccount.CardNumber, db),
                Id = bankAccount.Id
            };

            ViewBank.Bank.BankName = bankAccount.BankName;


            return View(ViewBank);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BankAccountNumber,CardNumber,Bank")] BankConstructor ViewBank)
        {
            if (ModelState.IsValid)
            {
                var bankAccount = db.BankAccount.Find(ViewBank.Id);

                if(ViewBank.BankAccountNumber != string.Empty)
                    bankAccount.BankAccountNumber = Rsa.RsaEncrypt(ViewBank.BankAccountNumber, db);
                if (ViewBank.CardNumber != string.Empty)
                    bankAccount.CardNumber = Rsa.RsaEncrypt(ViewBank.CardNumber, db);


                bankAccount.BankName = ViewBank.Bank.BankName;

                bankAccount.LastEditTime = DateTime.Now;

                db.Entry(bankAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ViewBank);
        }

        // GET: BankAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccount.FindAsync(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            var ViewBank = new BankConstructor()
            {
                BankAccountNumber = Rsa.RsaDecrypt(bankAccount.BankAccountNumber,db),
                CardNumber = Rsa.RsaDecrypt(bankAccount.CardNumber,db),
            };

            ViewBank.Bank.BankName = bankAccount.BankName;

            
            return View(ViewBank);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BankAccount bankAccount = await db.BankAccount.FindAsync(id);
            db.BankAccount.Remove(bankAccount);
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
