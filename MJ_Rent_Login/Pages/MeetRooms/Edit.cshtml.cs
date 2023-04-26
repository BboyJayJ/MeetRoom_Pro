using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.MeetRooms
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public EditModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MeetRoom MeetRoom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MeetRoom == null)
            {
                return NotFound();
            }

            var meetroom =  await _context.MeetRoom.FirstOrDefaultAsync(m => m.Id == id);
            if (meetroom == null)
            {
                return NotFound();
            }
            MeetRoom = meetroom;
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

            _context.Attach(MeetRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetRoomExists(MeetRoom.Id))
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

        private bool MeetRoomExists(int id)
        {
          return _context.MeetRoom.Any(e => e.Id == id);
        }
    }
}
