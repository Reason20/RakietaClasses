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
    public class LoadsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Loads
        public async Task<ActionResult> Index()
        {
            var loads = db.Loads.Include(l => l.Editor).Include(l => l.Facture).Include(l => l.Template);
            return View(await loads.ToListAsync());
        }

        // GET: Loads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loads loads = await db.Loads.FindAsync(id);
            if (loads == null)
            {
                return HttpNotFound();
            }
            return View(loads);
        }

        // GET: Loads/Create
        //public ActionResult Create()
        //{
        //    ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName");
        //    ViewBag.FactureId = new SelectList(db.Facture, "Id", "FactureNumber");
        //    ViewBag.TemplateId = new SelectList(db.Template, "Id", "Name");
        //    return View();
        //}

        //// POST: Loads/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Value,CrDate,EndDate,Interests,InTime,FactureId,Status,Comments,TemplateId,LastEditor")] Loads loads)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Loads.Add(loads);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", loads.LastEditor);
        //    ViewBag.FactureId = new SelectList(db.Facture, "Id", "FactureNumber", loads.FactureId);
        //    ViewBag.TemplateId = new SelectList(db.Template, "Id", "Name", loads.TemplateId);
        //    return View(loads);
        //}

        // GET: Loads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loads loads = await db.Loads.FindAsync(id);
            if (loads == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", loads.LastEditor);
            ViewBag.FactureId = new SelectList(db.Facture, "Id", "FactureNumber", loads.FactureId);
            ViewBag.TemplateId = new SelectList(db.Template, "Id", "Name", loads.TemplateId);
            return View(loads);
        }

        // POST: Loads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value,CrDate,EndDate,Interests,InTime,FactureId,Status,Comments,TemplateId,LastEditor")] Loads loads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loads).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditor = new SelectList(db.User, "Id", "FirstName", loads.LastEditor);
            ViewBag.FactureId = new SelectList(db.Facture, "Id", "FactureNumber", loads.FactureId);
            ViewBag.TemplateId = new SelectList(db.Template, "Id", "Name", loads.TemplateId);
            return View(loads);
        }

        // GET: Loads/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Loads loads = await db.Loads.FindAsync(id);
        //    if (loads == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(loads);
        //}

        //// POST: Loads/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Loads loads = await db.Loads.FindAsync(id);
        //    db.Loads.Remove(loads);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
