using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Pages.SalesReport
{
    public class DetailsModel : PageModel
    {
        private readonly MvcMovie.Models.AdventureWorksLT2012Context _context;

        public DetailsModel(MvcMovie.Models.AdventureWorksLT2012Context context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
