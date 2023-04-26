using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.Notifylnfos
{
    public class EditModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

       

        public EditModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notifylnfo Notifylnfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notifylnfo == null)
            {
                

                return NotFound();
            }

            var notifylnfo =  await _context.Notifylnfo.FirstOrDefaultAsync(m => m.Id == id);
            if (notifylnfo == null)
            {
                return NotFound();
            }
            Notifylnfo = notifylnfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notifylnfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotifylnfoExists(Notifylnfo.Id))
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

        private bool NotifylnfoExists(int id)
        {
          return _context.Notifylnfo.Any(e => e.Id == id);
        }
    }
}
