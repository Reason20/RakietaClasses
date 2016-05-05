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
    public class FacturesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Factures
        public async Task<ActionResult> Index()
        {
            var facture = db.Facture.Include(f => f.Club).Include(f => f.Contractor).Include(f => f.Editor).Include(f => f.UserCreate).Include(f => f.Person);
            return View(await facture.ToListAsync());
        }

        // GET: Factures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name");
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "Login");
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
            //ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OpDate,FactureNumber,NumberSeries,CrDate,Category,ContractorId,CreatorId,LastEditTime,LastEditor,InstallmentCount,Value,IsPaid,ClubId,UserId")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                facture.LastEditor = 52;
                facture.CreatorId = 52;
                db.Facture.Add(facture);
                await db.SaveChangesAsync();
                decimal suma = 0;
                for (int i=1; i<=facture.InstallmentCount; i++)
                {
                    var Model = new Loads
                    {
                        Value = decimal.Round((facture.Value / facture.InstallmentCount), 2, MidpointRounding.AwayFromZero),
                        CrDate = facture.OpDate,
                        EndDate = facture.OpDate.AddMonths(i),
                        Interests = 12.34,
                        InTime = false,
                        IsPaid = false,
                        FactureId = facture.Id,
                        Status = VindicationStatus.BrakDziałań
                    };
                    suma += Model.Value;
                    if(i==facture.InstallmentCount && suma!=facture.Value)
                    {
                        Model.Value += facture.Value - suma;
                    }
                    db.Loads.Add(Model);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", facture.UserId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            //ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", facture.UserId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            //ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OpDate,FactureNumber,NumberSeries,CrDate,Category,ContractorId,CreatorId,LastEditTime,LastEditor,InstallmentCount,Value,IsPaid,ClubId,UserId")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                facture.LastEditTime = DateTime.Now;
                db.Entry(facture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                int splaconeRaty = 0;
                decimal splaconaKwota = 0;
                foreach(Loads load in db.Loads)
                {
                    if (load.FactureId == facture.Id && load.IsPaid == true)
                    {
                        splaconeRaty++;
                        splaconaKwota += load.Value;
                    }

                }
                decimal suma = splaconaKwota;
                IList<Loads> lista = (from a in db.Loads where a.FactureId == facture.Id && a.IsPaid == false select a).ToList();
                //TODO ostatnia rata powinna w sumie z pozostałymi dać łączną kwotę
                
                foreach (Loads load in lista)
                {
                    if (load != lista[lista.Count - 1])
                    {
                        load.Value = decimal.Round(((facture.Value-splaconaKwota) / (facture.InstallmentCount - splaconeRaty)), 2, MidpointRounding.AwayFromZero);
                        suma += load.Value;
                        db.Entry(load).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        load.Value = facture.Value - suma;
                        db.Entry(load).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Club, "Id", "Name", facture.ClubId);
            ViewBag.ContractorId = new SelectList(db.Contractor, "Id", "Name", facture.ContractorId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Login", facture.UserId);
            //ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", facture.LastEditor);
            //ViewBag.CreatorId = new SelectList(db.User, "Id", "FirstName", facture.CreatorId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            foreach (Loads Load in db.Loads)
            {
                if (Load.FactureId == id)
                    db.Loads.Remove(Load);
            }
            Facture facture = await db.Facture.FindAsync(id);
            db.Facture.Remove(facture);
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
