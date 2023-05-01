using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;
using NuGet.Packaging.Signing;

namespace MJ_Rent_Login.Pages.Notifylnfos
{
    public class CreateModel : PageModel

    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public SelectList? UserIds { get; set; }

        public CreateModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var UserId_query = (from m in _context.Reserve
                               select m.UserId).Distinct();

            UserIds = new SelectList(UserId_query, "UserId");





            return Page();
        }

        [BindProperty]
        public Notifylnfo Notifylnfo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notifylnfo.Add(Notifylnfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
