using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.MeetRooms
{
    public class DetailsModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public DetailsModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
