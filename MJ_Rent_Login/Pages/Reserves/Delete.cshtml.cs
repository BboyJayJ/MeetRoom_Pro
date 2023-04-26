using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.Reserves
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public DeleteModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reserve Reserve { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserve.FirstOrDefaultAsync(m => m.Id == id);

            if (reserve == null)
            {
                return NotFound();
            }
            else 
            {
                Reserve = reserve;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }
            var reserve = await _context.Reserve.FindAsync(id);

            if (reserve != null)
            {
                Reserve = reserve;
                _context.Reserve.Remove(Reserve);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
