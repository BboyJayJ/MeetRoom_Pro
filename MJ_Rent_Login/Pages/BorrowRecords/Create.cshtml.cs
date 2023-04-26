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

namespace MJ_Rent_Login.Pages.BorrowRecords
{
    public class CreateModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public SelectList? Id1 { get; set; }

        public SelectList? UserId1 { get; set; }

        public CreateModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var query = from room in _context.MeetRoom
                        select new { room.Id, room.Name };


            Id1 = new SelectList(query, "Id", "Name");

            var UserId_query1 = from user in _context.Reserve
                               select user.UserId;

            UserId1 = new SelectList(UserId_query1, "UserId");

            return Page();
        }

        [BindProperty]
        public BorrowRecord BorrowRecord { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BorrowRecord.Add(BorrowRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
