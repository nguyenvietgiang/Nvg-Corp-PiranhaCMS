using Microsoft.EntityFrameworkCore;
using Nvg_Corp.Models;

namespace Nvg_Corp.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
