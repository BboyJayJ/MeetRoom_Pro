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

namespace MJ_Rent_Login.Pages.BorrowRecords
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
      public BorrowRecord BorrowRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BorrowRecord == null)
            {
                return NotFound();
            }

            var borrowrecord = await _context.BorrowRecord.FirstOrDefaultAsync(m => m.Id == id);

            if (borrowrecord == null)
            {
                return NotFound();
            }
            else 
            {
                BorrowRecord = borrowrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BorrowRecord == null)
            {
                return NotFound();
            }
            var borrowrecord = await _context.BorrowRecord.FindAsync(id);

            if (borrowrecord != null)
            {
                BorrowRecord = borrowrecord;
                _context.BorrowRecord.Remove(BorrowRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
