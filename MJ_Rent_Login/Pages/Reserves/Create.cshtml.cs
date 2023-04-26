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


namespace MJ_Rent_Login.Pages.Reserves
{
    public class CreateModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public SelectList? Ids { get; set; }

        


        public CreateModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> OnGetAsync()
        {
            //var roomQuery = from m in _context.MeetRoom
            //               select m;

            var roomQuery = from m in _context.MeetRoom
                            select new { m.Id, m.Name };

            Ids = new SelectList(roomQuery, "Id", "Name");
            //Ids = new SelectList(await roomQuery.Select(x=> x.Name).Distinct().ToListAsync());

            


            return Page();
        }

        [BindProperty]
        public Reserve Reserve { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reserve.Add(Reserve);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
