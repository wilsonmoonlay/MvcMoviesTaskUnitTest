using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class CustomerController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult IndexCustomer()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult WelcomeGuess()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult Details(int v)
        {
            throw new NotImplementedException();
        }
    }
}