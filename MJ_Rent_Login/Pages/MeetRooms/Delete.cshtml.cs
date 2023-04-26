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

namespace MJ_Rent_Login.Pages.MeetRooms
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
      public MeetRoom MeetRoom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MeetRoom == null)
            {
                return NotFound();
            }

            var meetroom = await _context.MeetRoom.FirstOrDefaultAsync(m => m.Id == id);

            if (meetroom == null)
            {
                return NotFound();
            }
            else 
            {
                MeetRoom = meetroom;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MeetRoom == null)
            {
                return NotFound();
            }
            var meetroom = await _context.MeetRoom.FindAsync(id);

            if (meetroom != null)
            {
                MeetRoom = meetroom;
                _context.MeetRoom.Remove(MeetRoom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
