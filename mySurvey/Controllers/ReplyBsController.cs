using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mySurvey.Models;

namespace mySurvey.Controllers
{
    public class ReplyBsController : Controller
    {
        private MySurveyEntities2 db = new MySurveyEntities2();

        // GET: ReplyBs
        public async Task<ActionResult> Index()
        {
            return View(await db.ReplyB.ToListAsync());
        }

        // GET: ReplyBs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyB replyB = await db.ReplyB.FindAsync(id);
            if (replyB == null)
            {
                return HttpNotFound();
            }
            return View(replyB);
        }

        // GET: ReplyBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReplyBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReplyBID,ReplyB_1,ReplyB_2,ReplyB_3,ReplyB_4,ReplyB_5,ReplyB_6,ReplyB_7,ReplyB_8,ReplyB_9,ReplyB_10")] ReplyB replyB)
        {
            if (ModelState.IsValid)
            {
                db.ReplyB.Add(replyB);
                await db.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }

            return View(replyB);
        }

        // GET: ReplyBs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyB replyB = await db.ReplyB.FindAsync(id);
            if (replyB == null)
            {
                return HttpNotFound();
            }
            return View(replyB);
        }

        // POST: ReplyBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReplyBID,ReplyB_1,ReplyB_2,ReplyB_3,ReplyB_4,ReplyB_5,ReplyB_6,ReplyB_7,ReplyB_8,ReplyB_9,ReplyB_10")] ReplyB replyB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replyB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(replyB);
        }

        // GET: ReplyBs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyB replyB = await db.ReplyB.FindAsync(id);
            if (replyB == null)
            {
                return HttpNotFound();
            }
            return View(replyB);
        }

        // POST: ReplyBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReplyB replyB = await db.ReplyB.FindAsync(id);
            db.ReplyB.Remove(replyB);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult YouHaveReplyed()
        {
            return View();
        }

        public ActionResult information()
        {
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
