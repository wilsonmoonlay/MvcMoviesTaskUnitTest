using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{


    public class NewCustomerController : Controller
    {
        private AdventureWorksLT2012Context db = new AdventureWorksLT2012Context();
        // GET: NewCustomer
        public ActionResult Index()
        {
            var customer = this.db.Customer.OrderBy(c => c.CustomerId);
            return View(customer.ToList());
        }

        // GET: NewCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View("Details");
        }

        // GET: NewCustomer/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: NewCustomer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Models.AdventureWorksLT2012Context db = new Models.AdventureWorksLT2012Context();
            Models.Customer Customer = new Models.Customer();
            
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid && Customer.FirstName != null && Customer.LastName != null && Customer.PasswordHash != null )
                    {
                        


                        db.Customer.Add(Customer);
                        db.SaveChanges();
                    
                    }
                


                }
                catch (Exception e)
                {
                    return View("Create");
                }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: NewCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewCustomer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Customer customerid = this.db.Customer.Find(id);

            try
            {
                // TODO: Add update logic here

                if (customerid == null)
                {
                    return this.HttpNotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch

            {
               
                return View();
            }
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // GET: NewCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewCustomer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}