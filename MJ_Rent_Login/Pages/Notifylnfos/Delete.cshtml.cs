using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.Notifylnfos
{
    public class DeleteModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public DeleteModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Notifylnfo Notifylnfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notifylnfo == null)
            {
                return NotFound();
            }

            var notifylnfo = await _context.Notifylnfo.FirstOrDefaultAsync(m => m.Id == id);

            if (notifylnfo == null)
            {
                return NotFound();
            }
            else 
            {
                Notifylnfo = notifylnfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Notifylnfo == null)
            {
                return NotFound();
            }
            var notifylnfo = await _context.Notifylnfo.FindAsync(id);

            if (notifylnfo != null)
            {
                Notifylnfo = notifylnfo;
                _context.Notifylnfo.Remove(Notifylnfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
