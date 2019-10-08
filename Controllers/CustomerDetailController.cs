using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class CustomerDetailController : Controller
    {
        // GET: CustomerDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerDetail/Delete/5
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