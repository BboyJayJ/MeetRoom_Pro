using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.BorrowRecords
{
    public class IndexModel : PageModel
    {
        public readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public IndexModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BorrowRecord> BorrowRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BorrowRecord != null)
            {
                BorrowRecord = await _context.BorrowRecord.ToListAsync();
            }
        }
    }
}
