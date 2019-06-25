using PurchaseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PurchaseTracker.Controllers
{
    public class PurchaseController : Controller
    {
        private PurchaseContext _purchaseDb = new PurchaseContext();

        //Create
        //GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        //Create
        //POST: Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(Purchase purchaseToAdd)
        {
            if (ModelState.IsValid)
            {
                _purchaseDb.Purchases.Add(purchaseToAdd);
                _purchaseDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseToAdd);
        }

        //Read
        // GET: Purchase
        public ActionResult Index()
        {
            return View(_purchaseDb.Purchases.ToList());
        }
        
        //Read
        // GET: Purchase/{id}
        public ActionResult ReadPurchase(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = _purchaseDb.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //Update
        //GET: Purchase/edit/{id}
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = _purchaseDb.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //Update
        //POST: Purchase/edit
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchaseToEdit)
        {
            if (ModelState.IsValid)
            {
                _purchaseDb.Entry(purchaseToEdit).State = EntityState.Modified;
                _purchaseDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseToEdit);
        }

        //Delete
        //GET: Purchase/delete/{id}
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = _purchaseDb.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //Delete
        //POST: Purchase/delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(Purchase purchaseToDelete)
        {
            _purchaseDb.Purchases.Remove(purchaseToDelete);
            _purchaseDb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}