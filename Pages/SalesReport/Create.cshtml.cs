using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;

namespace MvcMovie.Pages.SalesReport
{
    public class CreateModel : PageModel
    {
        private readonly MvcMovie.Models.AdventureWorksLT2012Context _context;

        public CreateModel(MvcMovie.Models.AdventureWorksLT2012Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name");
        ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderNumber");
            return Page();
        }

        [BindProperty]
        public SalesOrderDetail SalesOrderDetail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesOrderDetail.Add(SalesOrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}