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

namespace MJ_Rent_Login.Pages.Notifylnfos
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public IndexModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Notifylnfo> Notifylnfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Notifylnfo != null)
            {
                Notifylnfo = await _context.Notifylnfo.ToListAsync();
            }
        }
    }
}
