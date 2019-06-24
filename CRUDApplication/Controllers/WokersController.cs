using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDApplication.Models;

namespace CRUDApplication.Controllers
{
    public class WokersController : Controller
    {
        private EmployeesEntities db = new EmployeesEntities();

        // GET: Wokers
        public async Task<ActionResult> Index()
        {
            return View(await db.Wokers.ToListAsync());
        }

        // GET: Wokers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woker woker = await db.Wokers.FindAsync(id);
            if (woker == null)
            {
                return HttpNotFound();
            }
            return View(woker);
        }

        // GET: Wokers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wokers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,LastName,Department,Email,PhoneNumber")] Woker woker)
        {
            if (ModelState.IsValid)
            {
                db.Wokers.Add(woker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(woker);
        }

        // GET: Wokers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woker woker = await db.Wokers.FindAsync(id);
            if (woker == null)
            {
                return HttpNotFound();
            }
            return View(woker);
        }

        // POST: Wokers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,Department,Email,PhoneNumber")] Woker woker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(woker);
        }

        // GET: Wokers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woker woker = await db.Wokers.FindAsync(id);
            if (woker == null)
            {
                return HttpNotFound();
            }
            return View(woker);
        }

        // POST: Wokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Woker woker = await db.Wokers.FindAsync(id);
            db.Wokers.Remove(woker);
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
