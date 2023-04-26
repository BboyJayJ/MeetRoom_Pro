using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MJ_Rent_Login.Models.MeetRoom> MeetRoom { get; set; }
        public DbSet<MJ_Rent_Login.Models.BorrowRecord> BorrowRecord { get; set; }
        public DbSet<MJ_Rent_Login.Models.Reserve> Reserve { get; set; }
        public DbSet<MJ_Rent_Login.Models.Notifylnfo> Notifylnfo { get; set; }
        
    }
}