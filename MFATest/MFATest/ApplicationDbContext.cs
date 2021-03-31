using Microsoft.EntityFrameworkCore;

using MFATest.Models;


namespace MFATest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}
