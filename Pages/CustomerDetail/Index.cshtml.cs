using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Pages.CustomerDetail
{
    public class IndexModel : PageModel
    {
        private readonly MvcMovie.Models.AdventureWorksLT2012Context _context;

        public IndexModel(MvcMovie.Models.AdventureWorksLT2012Context context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
