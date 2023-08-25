using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PjJefersonSouza.Models;

namespace PjJefersonSouza.Data
{
    public class AppDbContext :
        IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Psychologist>? Psychologists { get; set; }

    }
}