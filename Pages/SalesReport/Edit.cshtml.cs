using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Pages.SalesReport
{
    public class EditModel : PageModel
    {
        private readonly MvcMovie.Models.AdventureWorksLT2012Context _context;

        public EditModel(MvcMovie.Models.AdventureWorksLT2012Context context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrderDetail SalesOrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOrderDetail = await _context.SalesOrderDetail
                .Include(s => s.Product)
                .Include(s => s.SalesOrder).FirstOrDefaultAsync(m => m.SalesOrderId == id);

            if (SalesOrderDetail == null)
            {
                return NotFound();
            }
           ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name");
           ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderNumber");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalesOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderDetailExists(SalesOrderDetail.SalesOrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _context.SalesOrderDetail.Any(e => e.SalesOrderId == id);
        }
    }
}
