using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.Reserves
{
    public class IndexModel : PageModel
    {
        public readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public IndexModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reserve> Reserve { get;set; } = default!;

        public List<string> RoomName = new();

        public async Task OnGetAsync()
        {
            if (_context.Reserve != null)
            {
                Reserve = await _context.Reserve.ToListAsync();

            }
            /*foreach (var reserve in Reserve)
            {
                int roomId =reserve.RoomId;
                var queryRoomName = from m in _context.MeetRoom
                                    where m.Id == roomId
                                    select m.Name;
                RoomName.Add(queryRoomName.First());
            }*/
        }

        
        

        
    }
}
